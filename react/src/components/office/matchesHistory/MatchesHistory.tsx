import { Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material'
import react, { useEffect, useState } from 'react'
import { IUser, IUserMatchesHistory } from '../../../shared/interfaces'
import Moment from 'moment'
import '../../../utils/listTemplate.scss'
import './style.scss'


export const MatchesHistory = ({user}: {user: IUser}) => {
    const [ascSorting, setAscSorting] = useState(true)
    const [matchesHistory, setMatchesHistory] = useState<IUserMatchesHistory[]>([])
    const isEmpty = user.userMatchesHistory.filter(x => x.isDone).length == 0
    useEffect(() => {
        const getHistory = () => {
            setMatchesHistory(user.userMatchesHistory.filter( x=> x.isDone).sort((a, b) => { 
                return new Date(a.matchDate).getTime() - new Date(b.matchDate).getTime()
            }).reverse())
        }

        getHistory()
    }, [])

    const handleAscSort = (sortBy: string) => {
        setAscSorting(false)

        switch(sortBy) {
            case 'teamA':
                const userSorted = user.userMatchesHistory.slice(0).sort((a, b) => { 
                    return (a.userClub > b.userClub ? 1 : -1) || a.userClub.localeCompare(b.userClub)
                })
                setMatchesHistory(userSorted)
                break
            case 'teamB':
                const enemySorted = user.userMatchesHistory.slice(0).sort((a, b) => { 
                    return (a.user2Club > b.user2Club ? 1 : -1) || a.user2Club.toString().localeCompare(b.user2Club.toString())
                })
                setMatchesHistory(enemySorted)
                break
            case 'date':
                const dateSorted = user.userMatchesHistory.slice(0).sort((a, b) => { 
                    return new Date(a.matchDate).getTime() - new Date(b.matchDate).getTime()
                })
                setMatchesHistory(dateSorted)
                break
        }
    }

    const handleDescSort = (sortBy: string) => {
        setAscSorting(true)

        switch(sortBy) {
            case 'teamA':
                const userSorted = user.userMatchesHistory.slice(0).sort((a, b) => { 
                    return (a.userClub > b.userClub ? -1 : 1) || a.userClub.localeCompare(b.userClub)
                })
                setMatchesHistory(userSorted)
                break
            case 'teamB':
                const enemySorted = user.userMatchesHistory.slice(0).sort((a, b) => { 
                    return (a.user2Club > b.user2Club ? -1 : 1) || a.user2Club.toString().localeCompare(b.user2Club.toString())
                })
                setMatchesHistory(enemySorted)
                break
            case 'date':
                const dateSorted = user.userMatchesHistory.slice(0).sort((a, b) => { 
                    return new Date(a.matchDate).getTime() - new Date(b.matchDate).getTime()
                }).reverse()
                setMatchesHistory(dateSorted)
                break
        }
    }

    return(
        <div className='matches-history-container'>
            <div className='table-container history-table-container'>
            {!isEmpty ? 
                <Table size="small" className='table'>
                    <TableHead className='table-head history-table-head'>
                        <TableRow className='table-head--row history-table-head'>
                            <TableCell align='center' className='table-head--cell click' onClick={() => ascSorting? handleAscSort('teamA') : handleDescSort('teamA')}>
                                Team A
                            </TableCell>
                            <TableCell align='center' className='table-head--cell'>
                                Score
                            </TableCell>
                            <TableCell align='center' className='table-head--cell blank'></TableCell>
                            <TableCell align='center' className='table-head--cell'>
                                Score
                            </TableCell>
                            <TableCell align="center" className='table-head--cell click' onClick={() => ascSorting? handleAscSort('teamB') : handleDescSort('teamB')}>
                                Team B
                            </TableCell>
                            <TableCell align='center' className='table-head--cell'>
                                MVP
                            </TableCell>
                            <TableCell align="center" className='table-head--cell click' onClick={() => ascSorting? handleAscSort('date') : handleDescSort('date')}>
                                Match date
                            </TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody className='table-body'>
                        {matchesHistory.map((match: IUserMatchesHistory) => {
                        return (
                            <TableRow key={match.id} className='table-body--row history-table-body--row'>
                                <TableCell align='center' className='table-body--cell'>{match.userClub}</TableCell>
                                <TableCell align='center' className='table-body--cell'>{match.userScore}</TableCell>
                                <TableCell align='center' className='table-body--cell blank'>:</TableCell>
                                <TableCell align='center' className='table-body--cell'>{match.user2Score}</TableCell>
                                <TableCell align='center' className='table-body--cell'>{match.user2Club}</TableCell>
                                <TableCell align='center' className='table-body--cell'>{match.mvp}</TableCell>
                                <TableCell align='center' className='table-body--cell'>{Moment(match.matchDate).format('DD.MM.YYYY')}</TableCell>
                            </TableRow>
                        )})}
                    </TableBody>
                </Table> :
                <div className='empty-table'>
                    There's no history yet.
                </div>}
            </div>
        </div>
    )
}