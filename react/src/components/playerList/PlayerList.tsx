import axios from 'axios';
import React, { useState, useEffect } from 'react'
import { IPlayer, IUser } from '../../shared/interfaces';
import '../../shared/subPageHelper.scss'

export const PlayerList = () => {
    const token = localStorage.getItem('user-id')
    const [players, setPlayers] = useState<IUser[]>([])
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        const fetchData = async () => {
            await axios.get<IUser[]>('https://localhost:44326/api/User')
                .then(res => {
                    setPlayers(res.data)
                })
                .catch(err => {
                    console.log(err)
                })
            setIsLoading(false)
        }

        fetchData()
    }, []);

    console.log(players)
    if (isLoading) {
        return <>Loading...</>
    } else {
        return (
            <div className='scrollable'>
                <div>Name: { players[4].name }</div>
                Country: { players[4].country }
                <ul>
                    { players.map((player: IUser) => {
                        return (
                        <div>
                            <li key={ player.id }>
                                <h2>Name: {player.name}</h2>
                                <h4>E-mail: {player.email}</h4>
                                <h4>Club: {player.clubName}</h4>
                            </li>
                        </div>
                        )
                    }) }
                    { }
                </ul>
            </div>
        )
    }

}