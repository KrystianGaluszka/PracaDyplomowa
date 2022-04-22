import React, { useEffect, useState } from 'react'
import { Container, Nav, Navbar, Dropdown, DropdownButton } from 'react-bootstrap';
import { NavLink, Route, Routes, useNavigate } from 'react-router-dom';
import axios from 'axios'
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css'
import "./style.scss"
import "./sidebars.scss"
import { HomePage } from '../homepage/HomePage';
import { Team } from '../team/Team';
import { TeamList } from '../team/team/TeamList';
import { SquadSettings } from '../team/squadSettings/SquadSettings';
import { IUser } from '../../shared/interfaces';
import { Office } from "../office/Office";
import { Profile } from "../office/profile/Profile";
import { News } from "../office/news/News";
import { Finances } from '../finances/Finances';
import { Shop } from '../finances/shop/Shop';
import { Inventory } from '../team/inventory/Inventory';
import { Expenses } from '../office/expenses/Expenses';
import { Stadium } from '../finances/stadium/Stadium';
import { Sponsors } from '../finances/sponsor/Sponsors';
import { TransferMarket } from '../finances/transferMarket/TransferMarket';
import { League } from '../league/League';
import { Table } from '../league/table/Table';
import { SeasonProgress } from '../league/seasonProgress/SeasonProgress';
import { MatchesHistory } from '../office/matchesHistory/MatchesHistory';
import { TopScorers } from '../league/topScorers/TopScorers';
import { PlayMatch } from '../league/playMatch/PlayMatch';
import { Match } from '../league/playMatch/match/Match';
import { Training } from '../team/training/Training';


let sitePath: string = window.location.pathname

export const Layout = () => {
    const [profilePicture, setProfilePicture] = useState('')
    const [username, setUsername] = useState('')
    const [sidebarName, setSidebarName] = useState('')
    const [isLoading, setIsLoading] = useState(true)
    const [logoImg, setLogoImg] = useState('')
    const [user, setUser] = useState<IUser>()
    const [useEffectRender, setUseEffectRender] = useState(false)
    const [newsCount, setNewsCount] = useState(0)
    const navigate = useNavigate()

    useEffect(() => {
        let interval: any = null;
        interval = setInterval(() => {
            setUseEffectRender(render => !render) // rerender useEffecta co 1s
          }, 1000)
        const getIds = async () => {
            if (!(sitePath === '/login' || sitePath === '/register' || sitePath === '/')) {
                let apiError: any
                await axios.get<IUser>(`https://localhost:44326/api/User/authuser`)
                    .then(res => {
                        setProfilePicture(res.data.profilePicturePath)
                        setUser(res.data)
                        if(res.data.name.length <= 5) {
                            setUsername(res.data.name)
                        } else {
                            setUsername(res.data.name.split(" ").map((n: any)=>n[0]).join(""))
                        }
                        setIsLoading(false)
                        setNewsCount(res.data.notifications.filter(x => !x.isRead).length)
                    }).catch(error => {
                        apiError = error
                        console.log(error)
                    })

                    if(apiError !== undefined) {
                        if(!(sitePath === '/login' || sitePath === '/register' || sitePath === '/')) {
                            navigate('/login', {
                                state: {
                                    isRedirected: true
                                }
                            })
                        }
                    }
                    setLogoImg('https://localhost:44326/images/logo/logoMini.png')
            }
        }
        // side bar name
        sitePath = window.location.pathname
        if(sitePath.includes('team')) setSidebarName('Team')
        if(sitePath.includes('transfer')) setSidebarName('Transfer')
        if(sitePath.includes('league')) setSidebarName('League')
        if(sitePath.includes('finances')) setSidebarName('Finances')
        if(sitePath.includes('office')) setSidebarName('Office')

        getIds()

        return () => clearInterval(interval);
    }, [useEffectRender])

    const OnClickLogout = async () => {
        await axios.post('https://localhost:44326/api/User/logout')
    }

    const sidebarItem = (path: string, name: string) => {
        return (
            <li className="side-bar--menu--item">
                <NavLink to={path} className="side-bar--menu--item--link" aria-current="page"> 
                    {name}
                    {path === '/office/news' ? 
                        sitePath.includes('office/news') ? '' : 
                        newsCount !== 0 ?
                        <div className='notification-icon news-icon'><span>{newsCount}</span></div> : ''
                    : ''}
                </NavLink>
            </li>
        )
    }

    const sideNavBar = () => {
        const path = window.location.pathname
        const checkPath = (pathName: string) => {
            return path.includes(pathName)
        }

        switch(true) {
            case checkPath('team'):
                return (
                    <ul className="side-bar--menu nav-pills">
                        {sidebarItem('/team/team', 'Team')}
                        {sidebarItem('/team/settings', 'Team settings')}
                        {sidebarItem('/team/training', 'Training')}
                        {sidebarItem('/team/inventory', 'Items')}
                    </ul>
                    
                )
            case checkPath('league'):
                return (
                    <ul className="side-bar--menu nav-pills">
                        {sidebarItem('/league/table', 'Table')}
                        {sidebarItem('/league/topscorers', 'Top scorers')}
                        {sidebarItem('/league/seasonProgress', 'Season progress')}
                        {sidebarItem('/league/play', 'Play Match')}
                    </ul>
                )
            case checkPath('finances'):
                return (
                    <ul className="side-bar--menu nav-pills">
                        {sidebarItem('/finances/shop', 'Shop')}
                        {sidebarItem('/finances/auction', 'Transfer Market')}
                        {sidebarItem('/finances/stadium', 'Stadium')}
                        {sidebarItem('/finances/sponsors', 'Sponsors')}
                    </ul>
                )
            case checkPath('office'):
                return (
                    <ul className="side-bar--menu nav-pills">
                        {sidebarItem('/office/profile', 'Profile')}
                        {sidebarItem('/office/news', 'News')}
                        {sidebarItem('/office/expenses', 'Expenses')}
                        {sidebarItem('/office/matcheshistory', 'Matches history')}
                    </ul>
                )
            default:
                return <></>
        }
    }

    if(isLoading) {
        return <></>
    } else {    
        if (sitePath === '/login' || sitePath === '/register' || sitePath === '/') {
            return <></>
        } else {
            return (
                <>
                <div className='layout-container'>
                    <Navbar className="navbar-container" expand="lg" variant="dark">
                        <Container>
                            <Navbar.Brand href="/home" className='brand-container'>
                                <div className='image-text'>BSM</div>
                                <div className="image">
                                    <img alt='logo' src={ logoImg } />
                                </div>
                            </Navbar.Brand>
                            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                            <Navbar.Collapse id="responsive-navbar-nav">
                                
                                <Nav className="navbar-menu me-auto">
                                    <Nav.Link className='navbar-menu--item' href="/team/team">Team</Nav.Link>
                                    <Nav.Link className='navbar-menu--item' href="/league/table">League</Nav.Link>
                                    <Nav.Link className='navbar-menu--item' href="/finances/shop">Finances</Nav.Link>
                                    <Nav.Link className='navbar-menu--item' href="/office/profile">Office</Nav.Link>
                                </Nav>
    
                                <DropdownButton 
                                    variant="secondary" 
                                    className='dropdown-toggle'  
                                    drop='down'
                                    title={<div className='dropdown-title'><img alt='profileIcon' src={ profilePicture }/> {username}</div>}
                                >
                                    <Dropdown.Item href="/office/news">
                                        News
                                        {newsCount !== 0 ? <div className='notification-icon news-icon'><span>{newsCount}</span></div> : ''}
                                    </Dropdown.Item>
                                    <hr/>
                                    <Dropdown.Item href="/office/profile">Profile</Dropdown.Item>
                                    <hr/>
                                    <Dropdown.Item className='dropdown-item' href="/" onClick={ OnClickLogout } >Logout</Dropdown.Item>
                                </DropdownButton>
                                {newsCount !== 0 ? <div className='notification-icon news-icon'><span>{newsCount}</span></div> : ''}
                            </Navbar.Collapse>
                        </Container>
                    </Navbar>
                    <hr style={{ height: 3, width: '100%', margin: 0 , backgroundColor: '#f86401', opacity: 1 }} />
                    {sitePath === '/home' ? '' : 
                    <div className="side-bar">
                        <span className="side-bar--name">{sidebarName}</span>
                        <hr className='hr'/>
                        {sideNavBar()}
                        <hr className='hr'/>
                    </div> 
                    }
                </div>

                <Routes>
                    <Route path="/home" element={ <HomePage user={user!} /> } />
                    <Route path="/office" element= { <Office /> } >
                        <Route path='profile' element={ <Profile userProp={user!}/> } />
                        <Route path='news' element={ <News user={user!} /> } />
                        <Route path='expenses' element={<Expenses expensesList={user?.expenses!}/>} />
                        <Route path='matcheshistory' element={<MatchesHistory user={user!} />} />
                    </Route>
                    <Route path='/team' element={<Team />} >
                        <Route path='team' element={<TeamList user={user!} usersPlayers={user?.usersPlayers!} />} />
                        <Route path='settings' element={<SquadSettings usersPlayers={user?.usersPlayers!} user={user!} />} />
                        <Route path='inventory' element={<Inventory user={user!} />} />
                        <Route path='training' element={<Training user={user!} />} />
                    </Route>
                    <Route path='/finances' element={<Finances user={user!} />}>
                        <Route path='shop' element={<Shop user={user!}/>} />
                        <Route path='stadium' element={<Stadium stadium={user?.stadium!} user={user!} />} />
                        <Route path='sponsors' element={<Sponsors user={user!} />} />
                        <Route path='auction' element={<TransferMarket user={user!} />} />
                    </Route>
                    <Route path='/league' element={<League />} >
                        <Route path='table' element={<Table user={user!} />} />
                        <Route path='seasonProgress' element={<SeasonProgress user={user!} />} />
                        <Route path='topscorers' element={<TopScorers/>} />
                        <Route path='play' element={<PlayMatch user={user!}/>} />
                        <Route path='play/match' element={<Match user={user!}/>} />
                    </Route>
                </Routes>
                </>
                
            )
        }
    }
}
