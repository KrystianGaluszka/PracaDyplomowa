import React, { useEffect, useState } from 'react'
import { IExpenses } from '../../../shared/interfaces'
import { Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import Moment from 'moment'
import '../../../utils/listTemplate.scss'
import './style.scss'



export const Expenses = ({expensesList}: {expensesList: IExpenses[]}) => {
    const [ascSorting, setAscSorting] = useState(true)
    const [list, setList] = useState<IExpenses[]>([])
    const isEmpty = expensesList.length == 0

    useEffect(() => {
        const getSortedList = () => {
            setList(expensesList.sort((a, b) => { 
                return new Date(a.transactionDate).getTime() - new Date(b.transactionDate).getTime()
            }).reverse())
        }

        getSortedList()
    }, [])

    const handleAscSort = (sortBy: string) => {
        setAscSorting(false)

        switch(sortBy) {
            case 'item':
                const nameSorted = expensesList.slice(0).sort((a, b) => { 
                    return (a.itemName > b.itemName ? 1 : -1) || a.itemName.localeCompare(b.itemName)
                })
                setList(nameSorted)
                break
            case 'date':
                const surnameSorted = expensesList.slice(0).sort((a, b) => { 
                    return new Date(a.transactionDate).getTime() - new Date(b.transactionDate).getTime()
                })
                setList(surnameSorted)
                break
            case 'count':
                const countrySorted = expensesList.slice(0).sort((a, b) => { 
                    return (a.count > b.count ? 1 : -1) || a.count.toString().localeCompare(b.count.toString())
                })
                setList(countrySorted)
                break
            case 'value':
                const lvlSorted = expensesList.slice(0).sort((a, b) => { 
                    return (a.value > b.value ? 1 : -1) || a.value.toString().localeCompare(b.value.toString())
                })
                setList(lvlSorted)
                break
        }
    }

    const handleDescSort = (sortBy: string) => {
        setAscSorting(true)

        switch(sortBy) {
            case 'item':
                const nameSorted = expensesList.slice(0).sort((a, b) => { 
                    return (a.itemName > b.itemName ? -1 : 1) || a.itemName.localeCompare(b.itemName)
                })
                setList(nameSorted)
                break
            case 'date':
                const surnameSorted = expensesList.slice(0).sort((a, b) => { 
                    return new Date(a.transactionDate).getTime() - new Date(b.transactionDate).getTime()
                }).reverse()
                setList(surnameSorted)
                break
            case 'count':
                const countrySorted = expensesList.slice(0).sort((a, b) => { 
                    return (a.count > b.count ? -1 : 1) || a.count.toString().localeCompare(b.count.toString())
                })
                setList(countrySorted)
                break
            case 'value':
                const lvlSorted = expensesList.slice(0).sort((a, b) => { 
                    return (a.value > b.value ? -1 : 1) || a.value.toString().localeCompare(b.value.toString())
                })
                setList(lvlSorted)
                break
        }
    }

    
    return (
        <div className='expenses-container'>
            <div className='table-container expense-table-container'>
                {!isEmpty ?
                <Table size="small" className='table'>
                    <TableHead className='table-head expense-table-head'>
                        <TableRow className='table-head--row expense-table-head--row'>
                            <TableCell align='left' className='table-head--cell expense-table-head--cell item-icon'></TableCell>
                            <TableCell 
                                align='center' 
                                className='table-head--cell expense-table-head--cell item click'
                                onClick={() => ascSorting? handleAscSort('item') : handleDescSort('item')}
                            >
                                Item
                            </TableCell>
                            <TableCell 
                                align='center' 
                                className='table-head--cell expense-table-head--cell date click'
                                onClick={() => ascSorting? handleAscSort('date') : handleDescSort('date')}
                            >
                                Purchase date
                            </TableCell>
                            <TableCell 
                                align='center' 
                                className='table-head--cell expense-table-head--cell count click'
                                onClick={() => ascSorting? handleAscSort('count') : handleDescSort('count')}
                            >
                                Count
                            </TableCell>
                            <TableCell 
                                align="right" 
                                className='table-head--cell expense-table-head--cell value click'
                                onClick={() => ascSorting? handleAscSort('value') : handleDescSort('value')}
                            >
                                Value
                            </TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody className='table-body expense-table-body'>
                        {list.map((expense: IExpenses) => (
                            <TableRow key={expense.id} className='table-body--row expense-table-body--row'>
                                <TableCell align='left' className='table-body--cell expense-table-body--cell item-icon'><img alt='itemIcon' src={expense.iconPath}/></TableCell>
                                <TableCell align='center' className='table-body--cell expense-table-body--cell item'>{expense.itemName}</TableCell>
                                <TableCell align='center' className='table-body--cell expense-table-body-cell date'>{Moment(expense.transactionDate).format('DD.MM.YYYY')}</TableCell>
                                <TableCell align='center' className='table-body--cell expense-table-body-cell count'>{expense.count}</TableCell>
                                <TableCell align="right" className='table-body--cell expense-table-body-cell value'>{expense.value}$</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table> :
                <div className='empty-table'>There's no expenses history yet.</div>}
            </div>
            
        </div>
    )
}