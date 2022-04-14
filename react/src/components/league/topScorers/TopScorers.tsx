import react, { useEffect, useState } from 'react'
import { Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import './style.scss'
import axios from 'axios';
import { IUsersPlayer } from '../../../shared/interfaces';

export const TopScorers = () => {
    const [usersPlayers, setUsersPlayers] = useState<IUsersPlayer[]>([])
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        const getUsersPlayers = async () => {
            const topPlayersCount = 100
            await axios.get<IUsersPlayer[]>('https://localhost:44326/api/Player/usersplayers')
                .then(res => {
                    setUsersPlayers(res.data.filter(x => x.score !== 0).slice(0, topPlayersCount).sort((a, b) => { 
                    return (a.score > b.score ? -1 : 1) || a.score.toString().localeCompare(b.score.toString())
                    }))
                    setIsLoading(false)
                })
                .catch(error => console.log(error))
        }
        getUsersPlayers()
    }, [])

    if (isLoading) {
        return <></>
    } else {
        return(
            <div className='top-scorers-container'>
                <div className='table-container top-scorers-table-container'>
                    { usersPlayers.length != 0 ?
                    <Table size="small" className='table top-scorers-table'>
                        <TableHead className='table-head top-scorers-table-head'>
                            <TableRow className='table-head--row top-scorers-table-head--row'>
                                <TableCell align='left' className='table-head--cell expense-table-head--cell number'>
                                    No.
                                </TableCell>
                                <TableCell align='center' className='table-head--cell top-scorers-table-head--cell'>
                                    Player
                                </TableCell>
                                <TableCell align='center' className='table-head--cell top-scorers-table-head--cell'>
                                    Club
                                </TableCell>
                                <TableCell align='center' className='table-head--cell top-scorers-table-head--cell'>
                                    Score
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody className='table-body top-scorers-table-body'>
                            {usersPlayers.map((userPlayer: IUsersPlayer, index) => (
                                <TableRow key={index + 1} className='table-body--row top-scorers-table-body--row'>
                                    <TableCell align='left' className='table-body--cell top-scorers-table-body--cell number'>{index + 1}.</TableCell>
                                    <TableCell align='center' className='table-body--cell top-scorers-table-body--cell '>{userPlayer.player.name} {userPlayer.player.surname}</TableCell>
                                    <TableCell align='center' className='table-body--cell top-scorers-table-body--cell '>{userPlayer.user.clubName}</TableCell>
                                    <TableCell align="center" className='table-body--cell top-scorers-table-body--cell score'>{userPlayer.score} points</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                    : 
                    <div className='empty-top'>
                        There's no players with any score.
                    </div>}
                </div>
            </div>
        )
    }
}