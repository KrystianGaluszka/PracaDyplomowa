import React, { useEffect, useState } from 'react'
import { Container, Nav, Navbar, Dropdown, DropdownButton } from 'react-bootstrap';
import { Navigate, NavLink, useNavigate } from 'react-router-dom';
import { IUser } from '../../shared/interfaces';
import axios from 'axios';
import logoImg from '../../logo/logoMini.png'
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css'
import "./style.scss"
import "./sidebars.scss"


let sitePath: string = window.location.pathname

export const Layout = () => {
    const [profilePicture, setProfilePicture] = useState('')
    const [username, setUsername] = useState('')
    const [sidebarName, setSidebarName] = useState('')
    const [isLoading, setIsLoading] = useState(true)
    const navigate = useNavigate()

    useEffect(() => { 
        const getIds = async () => {
            let apiError: any
            await axios.get(`https://localhost:44326/api/User/authuser`)
                .then(res => {
                    setProfilePicture(`https://localhost:44326/images/profilePics/${res.data.profilePicturePath}`)
                    if(res.data.name.length <= 5) {
                        setUsername(res.data.name)
                    } else {
                        setUsername(res.data.name.split(" ").map((n: any)=>n[0]).join(""))
                    }
                    setIsLoading(false)
                }).catch(error => {
                    apiError = error
                    console.log(error)
                })

                if(apiError !== undefined) { // ogarnąć żeby przesłac bool'a by pokazać alert!
                    navigate('/login', {
                        state: {
                            isRedirected: true
                        }
                    })
                }
        }
        const path = window.location.pathname
        // side bar name
        if(path.includes('team')) setSidebarName('Team')
        if(path.includes('transfer')) setSidebarName('Transfer')
        if(path.includes('league')) setSidebarName('League')
        if(path.includes('finances')) setSidebarName('Finances')
        if(path.includes('office')) setSidebarName('Office')

        getIds()
    }, [])

    const OnClickLogout = async () => {
        await axios.post('https://localhost:44326/api/User/logout')
            .then(res => console.log(res.data))
         
    }

    const sidebarItem = (path: string, name: string) => {
        return (
            <li className="side-bar--menu--item">
                <NavLink to={path} className="side-bar--menu--item--link" aria-current="page"> 
                    {name}
                </NavLink>
            </li>
        )
    }

    const sideNavBar = () => {
        const path = window.location.pathname

        switch(path) {
            case '/team/team':
            case '/team/training':
            case '/team/amateurs':
                return (
                    <ul className="side-bar--menu nav-pills">
                        {sidebarItem('/team/team', 'Team')}
                        {sidebarItem('/team/training', 'Training')}
                        {sidebarItem('/team/amateurs', 'Amateurs')}
                    </ul>
                    
                )
            case '/league':
            case '/league/table':
            case '/league/stars':
            case '/league/topScorers':
            case '/league/stadiums':
                return (
                    <ul className="side-bar--menu nav-pills">
                        {sidebarItem('/league/table', 'Table')}
                        {sidebarItem('/league/stars', 'Superstars')}
                        {sidebarItem('/league/topScorers', 'Top scorers')}
                        {sidebarItem('/league/stadiums', 'Stadiums')}
                    </ul>
                )
            case '/finances':
            case '/finances/expenses':
            case '/finances/sponsors':
            case '/finances/auction':
            case '/finances/shop':
                return (
                    <ul className="side-bar--menu nav-pills">
                        {sidebarItem('/finances/expenses', 'Expenses')}
                        {sidebarItem('/finances/sponsors', 'Sponsors')}
                        {sidebarItem('/finances/shop', 'Shop')}
                        {sidebarItem('/finances/auction', 'Transfer Market')}
                    </ul>
                )
            case '/office':
            case '/office/timetable':
            case '/office/news':
            case '/office/profile':
            case '/office/matchesHistory':
                return (
                    <ul className="side-bar--menu nav-pills">
                        {sidebarItem('/office/timetable', 'Timetable')}
                        {sidebarItem('/office/news', 'News')}
                        {sidebarItem('/office/profile', 'Profile')}
                        {sidebarItem('/office/matchesHistory', 'Matches history')}
                    </ul>
                )
            default:
                return <></>
        }
    }

    if(isLoading) {
        return <div className='layoutContainer'></div>
    } else {    
        if (sitePath === '/login' || sitePath === '/register' || sitePath === '/') {
            return <></>
        } else {
            return (
                <div className='layout-container'>
                    <Navbar className="navbar-container" expand="lg" variant="dark">
                        <Container>
                            <Navbar.Brand href="/home" className='brand-container'>
                                <div className='image-text'>BSM</div>
                                <div className="image">
                                    <img src={ logoImg } />
                                </div>
                            </Navbar.Brand>
                            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                            <Navbar.Collapse id="responsive-navbar-nav">
                                
                                <Nav className="navbar-menu me-auto">
                                    <Nav.Link className='navbar-menu--item' href="/team/team">Team</Nav.Link>
                                    <Nav.Link className='navbar-menu--item' href="/league/table">League</Nav.Link>
                                    <Nav.Link className='navbar-menu--item' href="/finances/expenses">Finances</Nav.Link>
                                    <Nav.Link className='navbar-menu--item' href="/office/timetable">Office</Nav.Link>
                                </Nav>
    
                                <DropdownButton 
                                    variant="secondary" 
                                    className='dropdown-toggle'  
                                    drop='down'
                                    title={<div className='dropdown-title'><img src={ profilePicture }/> {username}</div>}>
                                        <Dropdown.Item href="/register">Register</Dropdown.Item>
                                        <hr/>
                                        <Dropdown.Item href="/office/profile">Profile</Dropdown.Item>
                                        <hr/>
                                        <Dropdown.Item className='dropdown-item' href="/" onClick={ OnClickLogout } >Logout</Dropdown.Item>
                                </DropdownButton>
                            </Navbar.Collapse>
                        </Container>
                    </Navbar>
                    <hr style={{ height: 3, width: '100%', margin: 0 , backgroundColor: '#f86401', opacity: 1 }} />
                    {// maybe we can improve this code?
                    }
                    {sitePath === '/home' ? '' : 
                    <div className="side-bar">
                        <span className="side-bar--name">{sidebarName}</span>
                        <hr className='hr'/>
                        {sideNavBar()}
                        <hr className='hr'/>
                    </div> 
                    }
                </div>
            )
        }
    }
}
