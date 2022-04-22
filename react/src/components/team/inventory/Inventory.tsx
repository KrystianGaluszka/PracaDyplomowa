import { Radio, Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material'
import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Alert, Modal } from 'react-bootstrap'
import { IUser, IUsersItems, IUsersPlayer } from '../../../shared/interfaces'
import './style.scss'

export const Inventory = ({user}: {user: IUser}) => {
    const [useEffectRender, setUseEffectRender] = useState(false)
    const [showChestModal, setChestModal] = useState(false)
    const [showItemModal, setItemModal] = useState(false)
    const [isSuccess, setIsSuccess] = useState(false)
    const [itemList, setItemList] = useState<IUsersItems[]>([])
    const [clickedChest, setClickedChest] = useState<IUsersItems>()
    const [clickedItem, setClickedItem] = useState<IUsersItems>()
    const [playerList, setPlayerList] = useState<IUsersPlayer[]>([])
    const [selectedOption, setSelectedOption] = useState('')
    const [droppedPlayers, setDroppedPlayers] = useState<IUsersPlayer[]>([])
    const [isDropped, setIsDropped] = useState(false)

    const handleCloseChestModal = () => {
        setChestModal(false)
        setIsDropped(false)
        setDroppedPlayers([])
    }
    const handleCloseItemModal = () => setItemModal(false)

    useEffect(() => {
        let interval: any = null;
        interval = setInterval(() => {
            setUseEffectRender(render => !render) // rerender useEffecta co 1s
          }, 1000)

        const getItems = () => {
            setItemList(user.usersItems.filter(x => x.item.name != 'Contracts'))
        }

        getItems()

        return () => clearInterval(interval);
    }, [useEffectRender])

    const onClickUse = (itemName: string) => {
        const item = user.usersItems.find(x => x.item.name === itemName)
        if(itemName === 'Med-Kit' || itemName === 'XP-Boost' || itemName === 'Contracts') {
            setItemModal(true)
            setClickedItem(item)
            
            switch(itemName) {
                case 'Med-Kit':
                    setPlayerList(user.usersPlayers.filter(x => x.usersPlayerState.isInjured == true))
                    break
                case 'XP-Boost':
                    setPlayerList(user.usersPlayers.filter(x => x.usersPlayerState.isBoosted == false))
                    break
            }
        } else {
            setChestModal(true)
            setClickedChest(item)
        }
    }

    const onClickUseItem = async () => {
        const userItemId = clickedItem?.id
        const userPlayerId = selectedOption
        const data = {userItemId, userPlayerId}

        let response: any
        await axios.put('https://localhost:44326/api/Item/useitem', data)
            .then(res => response = res.data)
            .catch(error => console.log(error))
        
        if (response === 'success') {
            setItemModal(false)
            setChestModal(false)
            setIsSuccess(true)
            window.setTimeout(() => {
                window.location.reload()
            }, 600)
        }
    }

    const onClickOpenChest = async (userItemId: number) => {
        const userId = user.id
        const data = {userId, userItemId}

        await axios.put<IUsersPlayer[]>('https://localhost:44326/api/Item/openChest', data)
            .then(res => {
                setDroppedPlayers(res.data)
            })
            .catch(error => console.log(error))
        setIsDropped(true)
    }

    const onClickCloseChest = () => {
        setIsDropped(false)
        handleCloseChestModal()
        setDroppedPlayers([])
    }

    const onChangeSetValue = (e: any) => {
        setSelectedOption(e.target.value)
    }

    return (
        <div className='inventory-container'>
            {isSuccess ? 
                <Alert variant='success' className='success-alert alert'  show={isSuccess}> 
                    <Alert.Heading className='alert-header'>Used successfully </Alert.Heading>
                </Alert> 
            : '' }
            <div className='table-container items-list-container'>
                <Table size="small" className='table item-table'>
                <TableHead className='table-head'>
                    <TableRow className='table-head--row item-head'>
                        <TableCell className='table-head--cell item-head-cell'></TableCell>
                        <TableCell className='table-head--cell item-head-cell'>Item</TableCell>
                        <TableCell className='table-head--cell item-head-cell'>Count</TableCell>
                        <TableCell align="right" className='table-head--cell item-head-cell use-cell'></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody className='table-body items-table-body'>
                    {itemList.map((item: IUsersItems) => {
                        let buttonName = ''
                        
                        if (item.item.name.includes('chest')) {
                            buttonName = 'Open'
                        } else {
                            buttonName = 'Use'
                        }

                        if (item.item.name !== 'Contracts') {
                            return (
                                <TableRow key={item.id} className='table-body--row item-row' >
                                    <TableCell className='table-body--cell item-cell'><img src={item.item.iconPath}/></TableCell>
                                    <TableCell className='table-body--cell item-cell'>{item.item.name}</TableCell>
                                    <TableCell className='table-body--cell item-cell'>{item.count}</TableCell>
                                    <TableCell align="right" className='table-body--cell item-cell'>
                                        {item.count !== 0 ? <button className='btn-orange use-btn' onClick={() => onClickUse(item.item.name)}>{buttonName}</button> : 
                                            <button className='btn-orange use-btn orange-disabled' disabled>{buttonName}</button>}
                                    </TableCell>
                                </TableRow>
                            )
                        } else return <></>
                    })}
                </TableBody>
                </Table>

                <Modal dialogClassName='inventory-chest-modal' show={showChestModal} onHide={handleCloseChestModal}>
                    <Modal.Header className='inv-chest-header'>
                        <Modal.Title className='inv-chest--title'>Click open to draw 3 new players</Modal.Title>
                    </Modal.Header>
                    <Modal.Body className='inv-chest-body'>
                        {isDropped ?
                        <div className='inv-chest-players'>
                            {droppedPlayers.map((player: IUsersPlayer) => {
                            let textColor = '#d4d4d4'
                            switch(player.player.rarity) {
                            case 'Uncommon':
                                textColor = '#00dd00'
                                break;
                            case 'Rare':
                                textColor = '#07dcf8'
                                break;
                            case 'Epic':
                                textColor = '#cb00dd'
                                break;
                            case 'Masterwork':
                                textColor = '#dd8500'
                                break;
                            case 'Legendary':
                                textColor = '#ccc01b'
                                break;
                            }

                            return(
                                <div key={player.id} className='player-card' style={{border: `3px solid ${textColor}`}}>
                                    <div className='card-name'>
                                        {player.player.name} {player.player.surname}
                                    </div>
                                    <div className='card-content'>
                                        <div className='level content'>
                                            <div className='text'>Level</div>
                                            <div className='value'>{player.level}</div>
                                        </div>
                                        <div className='rarity content'>
                                            <div className='text'>Rarity</div>
                                            <div className='value'>{player.player.rarity}</div>
                                        </div>
                                        <div className='country content'>
                                            <div className='text'>Country</div>
                                            <div className='value'>{player.player.country}</div>
                                        </div>
                                    </div>
                                </div>
                            )
                            })}
                        </div>
                        : ''}
                        <div className='inv-chest-click'>
                            {!isDropped ?
                            <button className='btn-blue' onClick={() => onClickOpenChest(clickedChest?.id!)} >Open</button> :
                            <button className='btn-blue' onClick={() => onClickCloseChest()} >Close</button>
                            }
                        </div>
                    </Modal.Body>
                </Modal>

                <Modal dialogClassName='inventory-item-modal' show={showItemModal} onHide={handleCloseItemModal}>
                    <Modal.Header className='inv-item-header'>
                        <Modal.Title className='inv-item--title'>Choose player to use item</Modal.Title>
                    </Modal.Header>
                    <Modal.Body className='inv-item-body'>
                    {playerList.length !== 0 ? 
                        <div className='body-container'>
                            <div className='inv-item-table'>
                                
                                <Table size="small" className='table'>
                                    <TableBody className='table-body'>
                                        {playerList.map((player: IUsersPlayer) => (
                                            <TableRow key={player.id} className='table-body--row' >
                                                <TableCell className='table-body--cell'>
                                                    <Radio className='player-radio' 
                                                        value={player.id} 
                                                        checked={selectedOption === player.id.toString()} 
                                                        onChange={(e: any) => onChangeSetValue(e)}
                                                    />
                                                </TableCell>
                                                <TableCell className='table-body--cell'>{player.player.name}</TableCell>
                                                <TableCell className='table-body--cell'>{player.player.surname}</TableCell>
                                                <TableCell align="right" className='table-body--cell'>{player.level}</TableCell>
                                            </TableRow>
                                        ))}
                                    </TableBody>
                                </Table> 
                            </div>
                            <div className='use-button'>
                                <button className='btn-blue' onClick={onClickUseItem}>Use</button>
                            </div> 
                        </div> : 
                        <div className='no-content'>There's no injured players</div>}
                    </Modal.Body>
                </Modal>
            </div>
        </div>
    )
}