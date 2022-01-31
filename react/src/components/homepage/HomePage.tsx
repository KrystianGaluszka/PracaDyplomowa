import React, { useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import { Navigate } from 'react-router-dom';
import Moment from 'moment'
import './style.scss'
import axios from 'axios';
import { IUser, IUsersPlayer } from '../../shared/interfaces';

const HomePage = () => {
    const token = localStorage.getItem('user-id')
    const [user, setUser] = useState<IUser>()
    const [teamLvl, setTeamLvl] = useState<number>(0)
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {

        const fetchData = async () => {
            let response: IUser
            await axios.get<IUser>(`https://localhost:44326/api/User/${ token }`)
                .then(res => {
                    response = res.data
                    setUser(response)

                    response.usersPlayers.map((userPlayer: IUsersPlayer) => {
                        setTeamLvl(teamLvl + userPlayer.level)
                    })

                    setIsLoading(false)
                })
        }
        fetchData()
    }, []);
    console.log(isLoading)
    if (isLoading) {
        return <div className='homeContainer'></div>
    }
    else {
        return (
            <div className='homeContainer'>
                <div className='header' >
                    <div className='header--name'>Name: { user?.name }</div>
                    <div className='header--club-name'>Club: { user?.clubName}</div>
                    <div className='header--money'>Money: { user?.money }$</div>
                    <div className='header--team-level'>Level: {teamLvl}</div>
                </div>
                <h1>HOME PAGE</h1>
                <h5>Token:  { token }</h5>
                <h5>ID:  { user?.id }</h5>
                <h5>Uro: { Moment(user?.birthDate).format('d MMMM YYYY') }</h5>
            </div>
        )
    }
}

export default HomePage;