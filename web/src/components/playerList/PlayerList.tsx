import axios from 'axios';
import React, { useState, useEffect, ReactPropTypes } from 'react'
import { IPlayer } from './interfaces';

export const PlayerList = () => {
    const token = localStorage.getItem('user-id')
    const [players, setPlayers] = useState<IPlayer[]>([])
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        const fetchData = async () => {
            await axios.get<IPlayer[]>('https://localhost:44326/api/player')
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
            <div>
                <div>Name: { players[4].name }</div>
                Country: { players[4].country }
                <ul>
                    { players.map((player: IPlayer) => {
                        return (
                        <div>
                            <li key={ player.id }>
                                <h2>Name: {player.name}</h2>
                                <h4>League: {player.league}</h4>
                                <h4>Club: {player.club}</h4>
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