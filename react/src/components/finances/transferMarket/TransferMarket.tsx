import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Checkbox, Radio, Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import { Alert, Form, Modal } from 'react-bootstrap';
import { ModalRow } from '../../team/team/ModalRow';
import { IAuction, IUser, IUsersPlayer } from '../../../shared/interfaces'
import '../../../utils/listTemplate.scss'
import '../../../utils/noPlayerDiv.scss'
import './style.scss'

export const TransferMarket = ({user}: {user: IUser}) => {
    const [isLoading, setIsLoading] = useState(false)
    const [auctionList, setAuctionList] = useState<IAuction[]>([])
    const [ascSorting, setAscSorting] = useState(true)
    const [clickedAuction, setClickedAuction] = useState<IAuction>()
    const [rarityColor, setRarityColor] = useState('')
    const [show, setShow] = useState({
        bid: false,
        buy: false,
        quickSell: false,
        auction: false,
        remove: false,
        player: false,
    })
    const [quickSellPlayers, setQuickSellPlayers] = useState<number[]>([])
    const [removePlayers, setRemovePlayers] = useState<number[]>([])
    const [auctionValue, setAuctionValue] = useState(0)
    const [addAuctionValues, setAddAuctionValues] = useState({
        bid: 0,
        buy: 0,
    })
    const [isSuccess, setIsSuccess] = useState(false)
    const [isError, setIsError] = useState(false)
    const [alertMessage, setAlertMessage] = useState('')
    const [selectedOption, setSelectedOption] = useState('')
    const moneyFormatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 0
    })

    useEffect(() => {
        const getAuction = async () => {
            await axios.get<IAuction[]>('https://localhost:44326/api/Auction')
                .then(res => setAuctionList(res.data))
            setIsLoading(true)
        }

        getAuction()
    }, [])

    const handleShowModal = (modalName: string, auctionId?: number) => {
        const auction = auctionList.find(x => x.id === auctionId)

        switch(modalName){
            case 'player':
                setShow({...show, player: true})

                switch(auction?.usersPlayer.player.rarity) {
                    case 'Common':
                        setRarityColor('grey')
                        break;
                    case 'Uncommon':
                        setRarityColor('#00dd00')
                        break;
                    case 'Rare':
                        setRarityColor('#07dcf8')
                        break;
                    case 'Epic':
                        setRarityColor('#cb00dd')
                        break;
                    case 'Masterwork':
                        setRarityColor('#dd8500')
                        break;
                    case 'Legendary':
                        setRarityColor('#ccc01b')
                        break;
                }
                setClickedAuction(auction)
                break
            case 'bid':
                setShow({...show, bid: true})
                setClickedAuction(auction)
                break
            case 'buy':
                setShow({...show, buy: true})
                setClickedAuction(auction)
                break
            case 'quick':
                setShow({...show, quickSell: true})
                break
            case 'auction':
                setShow({...show, auction: true})
                break
            case 'remove':
                setShow({...show, remove: true})
                break
        }
    }

    const handleAscSort = (sortBy: string) => {
        setAscSorting(false)

        switch(sortBy) {
            case 'position':
                const positionSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.usersPlayer.player.position > b.usersPlayer.player.position ? 1 : -1) || a.usersPlayer.player.position.localeCompare(b.usersPlayer.player.position);
                })
                setAuctionList(positionSorted)
                break
            case 'player':
                const playerSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.usersPlayer.player.name > b.usersPlayer.player.name ? 1 : -1) || a.usersPlayer.player.name.localeCompare(b.usersPlayer.player.name);
                })
                setAuctionList(playerSorted)
                break
            case 'level':
                const levelSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.usersPlayer.level > b.usersPlayer.level ? 1 : -1) || a.usersPlayer.level.toString().localeCompare(b.usersPlayer.level.toString());
                })
                setAuctionList(levelSorted)
                break
            case 'team':
                const teamSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.usersPlayer.user.clubName > b.usersPlayer.user.clubName ? 1 : -1) || a.usersPlayer.user.clubName.localeCompare(b.usersPlayer.user.clubName);
                })
                setAuctionList(teamSorted)
                break
            case 'price':
                const priceSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.price > b.price ? 1 : -1) || a.price.toString().localeCompare(b.price.toString());
                })
                setAuctionList(priceSorted)
                break
        }
    }

    const handleDescSort = (sortBy: string) => {
        setAscSorting(true)

        switch(sortBy) {
            case 'position':
                const positionSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.usersPlayer.player.position > b.usersPlayer.player.position ? -1 : 1) || a.usersPlayer.player.position.localeCompare(b.usersPlayer.player.position);
                })
                setAuctionList(positionSorted)
                break
            case 'player':
                const playerSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.usersPlayer.player.name > b.usersPlayer.player.name ? -1 : 1) || a.usersPlayer.player.name.localeCompare(b.usersPlayer.player.name);
                })
                setAuctionList(playerSorted)
                break
            case 'level':
                const levelSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.usersPlayer.level > b.usersPlayer.level ? -1 : 1) || a.usersPlayer.level.toString().localeCompare(b.usersPlayer.level.toString());
                })
                setAuctionList(levelSorted)
                break
            case 'team':
                const teamSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.usersPlayer.user.clubName > b.usersPlayer.user.clubName ? -1 : 1) || a.usersPlayer.user.clubName.localeCompare(b.usersPlayer.user.clubName);
                })
                setAuctionList(teamSorted)
                break
            case 'price':
                const priceSorted = auctionList.slice(0).sort((a, b) => { 
                    return (a.price > b.price ? -1 : 1) || a.price.toString().localeCompare(b.price.toString());
                })
                setAuctionList(priceSorted)
                break
        }
    }

    const handleInput = (e: any) => {
        const value = e.target.value
        setAuctionValue(value)
    }

    const handleAddAuctionInput = (e: any) => {
        const name = e.target.name
        const value = e.target.value
        
        setAddAuctionValues({ ...addAuctionValues, [name]: value })
    }

    const onChangeSetValue = (e: any) => {
        setSelectedOption(e.target.value)
    }

    const handlePutForAuction = async () => {
        const userId = user.id
        const userPlayerId  = selectedOption
        const price = addAuctionValues.buy
        const bid = addAuctionValues.bid
        const data = { userId, userPlayerId, price, bid }

        let response: any
        await axios.post('https://localhost:44326/api/Auction/add', data)
            .then(res => response = res.data)
            .catch(error => console.log(error))

        if (response === 'success') {
            setAlertMessage('Player putted on auction successfully')
            setShow({...show, auction: false})
            setIsSuccess(true)
            window.setTimeout(() => {
                window.location.reload()
            }, 600)
        }
    }

    const handleCloseAddModal = () => {
        setShow({...show, auction: false})
        setSelectedOption('')
        setAddAuctionValues({...addAuctionValues, bid: 0})
        setAddAuctionValues({...addAuctionValues, buy: 0})
    }

    const handleCloseCheckboxModal = async (modalName: string) => {
        switch(modalName) {
            case 'quickSell':
                setShow({...show, quickSell: false})
                setQuickSellPlayers([])
                break
            case 'remove':
                setShow({...show, remove: false})
                setRemovePlayers([])
                break
        }
    }

    const handleQuickSell = async () => {
        const userPlayerIds  = quickSellPlayers
        const userId = user.id
        const data = {userPlayerIds, userId}
 
        let response: any
        await axios.put('https://localhost:44326/api/Auction/quicksell', data)
            .then(res => response = res.data)
            .catch(error => console.log(error))

        if (response === 'success') {
            setAlertMessage('Players selled successfully')
            setShow({...show, quickSell: false})
            setIsSuccess(true)
            window.setTimeout(() => {
                window.location.reload()
            }, 600)
        }
    }

    const handleRemove = async () => {
        const userPlayerIds  = removePlayers
 
        let response: any
        await axios.put('https://localhost:44326/api/Auction/remove', { userPlayerIds })
            .then(res => response = res.data)
            .catch(error => console.log(error))

        if (response === 'success') {
            setAlertMessage('Players removed successfully')
            setShow({...show, remove: false})
            setIsSuccess(true)
            window.setTimeout(() => {
                window.location.reload()
            }, 600)
        }
    }

    const handleQuickCheckbox = async (playerId: number) => {
        let updatedQuickSellPlayers = JSON.parse(JSON.stringify(quickSellPlayers))
        let find = updatedQuickSellPlayers.indexOf(playerId)

        if (find > -1) {
            updatedQuickSellPlayers.splice(find, 1)
        } else {
            updatedQuickSellPlayers.push(playerId)
        }

        setQuickSellPlayers(updatedQuickSellPlayers)
    }

    const handleRemoveCheckbox = async (playerId: number) => {
        let updatedQuickSellPlayers = JSON.parse(JSON.stringify(removePlayers))
        let find = updatedQuickSellPlayers.indexOf(playerId)

        if (find > -1) {
            updatedQuickSellPlayers.splice(find, 1)
        } else {
            updatedQuickSellPlayers.push(playerId)
        }

        setRemovePlayers(updatedQuickSellPlayers)
    }

    const handleBid = async () => {
        const auctionUserId = clickedAuction?.userId
        const auctionId = clickedAuction?.id
        const bid = auctionValue
        const userId = user.id
        const data = {auctionId, bid, userId}

        if (userId === auctionUserId) {
            setAlertMessage('Cannot bid own player')
            setShow({...show, bid: false})
            setIsError(true)
            window.setTimeout(() => {
                setIsError(false)
            }, 1500)
        } else if (user.money < bid) {
            setAlertMessage('You do not have enough money')
            setShow({...show, bid: false})
            setIsError(true)
            window.setTimeout(() => {
                setIsError(false)
            }, 1500)
        } else {
            let response: any
            await axios.put('https://localhost:44326/api/Auction/bid', data)
                .then(res => response = res.data)
                .catch(error => console.log(error))
    
            if (response === 'success') {
                setAlertMessage('Player bidded successfully')
                setShow({...show, bid: false})
                setIsSuccess(true)
                window.setTimeout(() => {
                    window.location.reload()
                }, 600)
            }
        }
    }
 
    const handleBuy = async () => {
        const auctionUserId = clickedAuction?.userId
        const auctionId = clickedAuction?.id!
        const userId = user.id
        const data = {auctionId, userId}

        if (userId === auctionUserId) {
            setAlertMessage('Cannot buy own player')
            setShow({...show, buy: false})
            setIsError(true)
            window.setTimeout(() => {
                setIsError(false)
            }, 1500)
        } else if (user.money < clickedAuction?.price!) {
            setAlertMessage('You do not have enough money')
            setShow({...show, buy: false})
            setIsError(true)
            window.setTimeout(() => {
                setIsError(false)
            }, 1500)
        } else {
            let response: any
            await axios.put('https://localhost:44326/api/Auction/buy', data)
                .then(res => response = res.data)
                .catch(error => console.log(error))
    
            if (response === 'success') {
                response = ''
                await axios.delete(`https://localhost:44326/api/Auction/deleteafterbuy/${auctionId}`)
                    .then(res => response = res.data)
                    .catch(error => console.log(error))
    
                if (response === 'success') {
                    setAlertMessage('Player purchased successfully')
                    setShow({...show, buy: false})
                    setIsSuccess(true)
                    window.setTimeout(() => {
                        window.location.reload()
                    }, 600)
                }
            }
        }
    }

    if (isLoading) {
        return (
            <div className='market-container table-container'>
                <Alert variant='success' className='alert market-alert'  show={isSuccess}> 
                    <Alert.Heading className='alert-header'>{alertMessage}</Alert.Heading>
                </Alert> 
                <Alert variant='danger' className='alert market-alert'  show={isError}> 
                    <Alert.Heading className='alert-header'>{alertMessage}</Alert.Heading>
                </Alert> 
                <div className='auction-panel'>
                    <button className='btn-orange quick-sell' onClick={() => handleShowModal('quick')}>QuickSell</button>
                    <button className='btn-orange add-player' onClick={() => handleShowModal('auction')}>Add Player</button>
                    <button className='btn-orange remove-player' onClick={() => handleShowModal('remove')}>Remove Player</button>
                </div>
                {auctionList.length > 0 ?
                <Table size="small" className='table market-table'>
                    <TableHead className='table-head market-table-head'>
                        <TableRow className='table-head--row market-table-head--row'>
                            <TableCell 
                                align='center'
                                className='table-head--cell market-table-head--cell click position' 
                                onClick={() => ascSorting? handleAscSort('position') : handleDescSort('position')}
                            >
                                P
                            </TableCell>
                            <TableCell 
                                align='left'
                                className='table-head--cell market-table-head--cell click player' 
                                onClick={() => ascSorting? handleAscSort('player') : handleDescSort('player')}
                            >
                                Player
                            </TableCell>
                            <TableCell 
                                align='center'
                                className='table-head--cell market-table-head--cell click level' 
                                onClick={() => ascSorting? handleAscSort('level') : handleDescSort('level')}
                            >
                                Level
                            </TableCell>
                            <TableCell 
                                align='center'
                                className='table-head--cell market-table-head--cell click price' 
                                onClick={() => ascSorting? handleAscSort('price') : handleDescSort('price')}
                            >
                                Buy now
                            </TableCell>
                            <TableCell 
                                align='center' 
                                className='table-head--cell market-table-head--cell click team'
                                onClick={() => ascSorting? handleAscSort('team') : handleDescSort('team')}
                            >
                                Bidding team
                            </TableCell>
                            <TableCell align='center' className='table-head--cell market-table-head--cell time'>
                                Timeleft
                            </TableCell>
                            <TableCell align='right' className='table-head--cell market-table-head--cell action'>
                                Action
                            </TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody className='table-body market-table-body'>
                        {auctionList.map((auction: IAuction) => {
                        return (
                            <TableRow key={auction.id} className='table-body--row market-table-body--row'>
                                <TableCell align='center' className='table-body--cell market-table-body--cell position'>{auction.usersPlayer.player.position}</TableCell>
                                <TableCell align='left' className='table-body--cell market-table-body--cell player'>
                                    <img src={auction.usersPlayer.player.picturePath} />  
                                    <span className='player-name' onClick={() => handleShowModal('player', auction.id)}>
                                        {auction.usersPlayer.player.name} {auction.usersPlayer.player.surname}
                                    </span>
                                </TableCell>
                                <TableCell align='center' className='table-body--cell market-table-body--cell level'>{auction.usersPlayer.level}</TableCell>
                                <TableCell align='center' className='table-body--cell market-table-body--cell price'>{moneyFormatter.format(auction.price)}</TableCell>
                                <TableCell align='center' className='table-body--cell market-table-body--cell team'>{auction.usersPlayer.user.clubName}</TableCell>
                                <TableCell align='center' className='table-body--cell market-table-body--cell time'>
                                    {auction.hours < 10 ? '0' + auction.hours.toString() : auction.hours}:{auction.minutes < 10 ? '0' + auction.minutes.toString() : auction.minutes}
                                </TableCell>
                                <TableCell align="right" className='table-body--cell market-table-body--cell action'>
                                    <a className='btn-orange bid action-btn' onClick={() => handleShowModal('bid', auction.id)}>Bid</a>
                                    <a className='btn-orange buy action-btn' onClick={() => handleShowModal('buy', auction.id)}>Buy</a>
                                </TableCell>
                            </TableRow>
                        )})}
                    </TableBody>
                </Table> :
                <div className='no-players'>
                    There's no players put on auction    
                </div>}
                
                <Modal dialogClassName='team-list-modal' show={show.player} onHide={() => setShow({...show, player: false})}>
                        <Modal.Header className='popup-header'>
                            <Modal.Title className='popup-title'>
                                {clickedAuction?.usersPlayer.player.name} {clickedAuction?.usersPlayer.player.surname}
                            </Modal.Title>
                        </Modal.Header>
                        <Modal.Body className='popup-body'>
                            <div className='body-content'>
                                <ModalRow title='Weight' content={`${clickedAuction?.usersPlayer.player.weight!} kg`}/>
                                <hr/>
                                <ModalRow title="Height" content={`${clickedAuction?.usersPlayer.player.height!} cm`} />
                                <hr/>
                                <ModalRow title="Country" content={clickedAuction?.usersPlayer.player.country!} />
                                <hr/>
                                <ModalRow title="Club" content={clickedAuction?.usersPlayer.player.club!} />
                                <hr/>
                                <ModalRow title="League" content={clickedAuction?.usersPlayer.player.league!} />
                                <hr/>
                                <ModalRow title="Level" content={clickedAuction?.usersPlayer.level!} />
                                <hr/>
                                <ModalRow title="Position" content={clickedAuction?.usersPlayer.player.position!} />
                                <hr/>
                                <ModalRow title="Rarity" color={rarityColor} content={clickedAuction?.usersPlayer.player.rarity!} />
                                <hr/>
                                <ModalRow title="Condition" content={`${(clickedAuction?.usersPlayer.condition!)}%`} />
                                <hr/>
                                <ModalRow title="Contracts" content={clickedAuction?.usersPlayer.contract!} />
                                <hr/>
                                <ModalRow title="Salary" content={clickedAuction?.usersPlayer.salary!} />
                            </div>
                        </Modal.Body>
                    </Modal>
    
                    <Modal dialogClassName='bid-auction' show={show.bid} onHide={() => setShow({...show, bid: false})}>
                        <Modal.Header className='bid-header'>
                            <div className='player'>
                                {clickedAuction?.usersPlayer.player.name} {clickedAuction?.usersPlayer.player.surname}
                            </div>
                            <div className='player-price'>
                                Bid: {moneyFormatter.format(clickedAuction?.bid!)}
                            </div>
                        </Modal.Header>
                        <Modal.Body className='bid-body'>
                            <div className='bid-container'>
                                <div className='auction-bid-value'>
                                    <Form.Control
                                        className='input-bid'
                                        type='number'
                                        dir="rtl"
                                        min={clickedAuction?.bid! + (clickedAuction?.bid! * 0.1)}
                                        max={user.money}
                                        size='sm'
                                        placeholder={(clickedAuction?.bid! + (clickedAuction?.bid! * 0.1)).toString()}
                                        onChange={ e => handleInput(e) }
                                    />
                                </div>
                                <div className='auction-btn'>
                                    <button className='btn-blue bid-btn' onClick={handleBid} >Bid</button>
                                </div>
                            </div>
                        </Modal.Body>
                    </Modal>
    
                    <Modal dialogClassName='buy-auction' show={show.buy}>
                        <Modal.Header className='buy-header'>
                            {clickedAuction?.usersPlayer.player.name} {clickedAuction?.usersPlayer.player.surname}
                        </Modal.Header>
                        <Modal.Body className='buy-body'>
                            Are you sure you want to buy this player?
                        </Modal.Body>
                        <Modal.Footer className='buy-footer'>
                            <button className='btn-orange yes-btn' onClick={handleBuy}>Yes</button>
                            <button className='btn-blue no-btn' onClick={() => setShow({...show, buy: false})}>No</button>
                        </Modal.Footer>
                    </Modal>
    
                    <Modal dialogClassName='add-auction' show={show.auction} onHide={() => setShow({...show, auction: false})}>
                        <Modal.Header className='add-auction-header'>
                            <div className='header-title'>Add on auction</div>
                            <div className='header-panel'>
                                <Form.Control
                                    className='input-bid'
                                    name='bid'
                                    type='number'
                                    dir="rtl"
                                    min='0'
                                    size='sm'
                                    placeholder='Bid price'
                                    onChange={ e => handleAddAuctionInput(e) }
                                    />
    
                                <Form.Control
                                    className='input-buy'
                                    name='buy'
                                    type='number'
                                    dir="rtl"
                                    min='0'
                                    size='sm'
                                    placeholder='Buy price'
                                    onChange={ e => handleAddAuctionInput(e) }
                                    />
                            </div>
                        </Modal.Header>
                        <Modal.Body className='add-auction-body'>
                        {user.usersPlayers.filter(x => x.usersPlayerState.isOnAuction === false).length > 0 ?
                        <Table size="small" className='table add-table'>
                            <TableBody className='table-body add-table-body'>
                                {user.usersPlayers.filter(x => x.usersPlayerState.isOnAuction === false).map((player: IUsersPlayer) => (
                                    <TableRow key={player.id} className='table-body--row add-table-body--row' >
                                        <TableCell className='table-body--cell add-table-body--cell'>
                                            <Radio className='player-radio' 
                                                value={player.id} 
                                                checked={selectedOption === player.id.toString()} 
                                                onChange={(e: any) => onChangeSetValue(e)}
                                            />
                                        </TableCell>
                                        <TableCell className='table-body--cell add-table-body--cell'>{player.player.name}</TableCell>
                                        <TableCell className='table-body--cell add-table-body--cell'>{player.player.surname}</TableCell>
                                        <TableCell align="right" className='table-body--cell add-table-body--cell'>{player.level}</TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table> :
                        <div className='no-players'>
                            You don't have any player to sell    
                        </div>}
                        </Modal.Body>
                        {selectedOption !== '' && addAuctionValues.bid !== 0 && addAuctionValues.buy !== 0 ? 
                        <Modal.Footer className='add-auction-footer'>
                            <button className='btn-orange confirm-btn' onClick={handlePutForAuction}>Confirm</button>
                            <button className='btn-orange cancel-btn' onClick={handleCloseAddModal}>Cancel</button>
                        </Modal.Footer> : ''}
                    </Modal>
    
                    <Modal dialogClassName='quick-sell-auction' show={show.quickSell} onHide={() => setShow({...show, quickSell: false})}>
                        <Modal.Header className='quick-sell-header'>
                            Quick sell
                        </Modal.Header>
                        <Modal.Body className='quick-sell-body'>
                        {user.usersPlayers.filter(x => x.usersPlayerState.isOnAuction === false).length > 0 ?
                        <Table size="small" className='table quick-sell-table'>
                            <TableBody className='table-body quick-sell-table-body'>
                                {user.usersPlayers.filter(x => x.usersPlayerState.isOnAuction === false).map((player: IUsersPlayer) => (
                                    <TableRow key={player.id} className='table-body--row quick-sell-table-body--row' >
                                        <TableCell className='table-body--cell quick-sell-table-body--cell'>
                                            <Checkbox className='player-radio' 
                                                value={player.id} 
                                                checked={quickSellPlayers.includes(player.id)} 
                                                onChange={() => handleQuickCheckbox(player.id)}
                                            />
                                        </TableCell>
                                        <TableCell className='table-body--cell quick-sell-table-body--cell'>{player.player.name}</TableCell>
                                        <TableCell className='table-body--cell quick-sell-table-body--cell'>{player.player.surname}</TableCell>
                                        <TableCell className='table-body--cell quick-sell-table-body--cell'>{player.level * 100}$</TableCell>
                                        <TableCell align="right" className='table-body--cell quick-sell-table-body--cell'>{player.level}</TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table> :
                        <div className='no-players'>
                            You don't have any player to sell    
                        </div>}
                        </Modal.Body>
                        <Modal.Footer className='quick-sell-footer'>
                            <button className='btn-orange confirm-btn' onClick={handleQuickSell}>Confirm</button>
                            <button className='btn-blue cancel-btn' onClick={() => handleCloseCheckboxModal('quickSell')}>Cancel</button>
                        </Modal.Footer>
                    </Modal>
    
                    <Modal dialogClassName='remove-auction' show={show.remove} onHide={() => setShow({...show, remove: false})}>
                        <Modal.Header className='remove-header'>
                            Remove from auction
                        </Modal.Header>
                        <Modal.Body className='remove-body'>
                        {user.usersPlayers.filter(x => x.usersPlayerState.isOnAuction).length > 0 ?
                        <Table size="small" className='table remove-table'>
                            <TableBody className='table-body remove-table-body'>
                                {user.usersPlayers.filter(x => x.usersPlayerState.isOnAuction).map((player: IUsersPlayer) => (
                                    <TableRow key={player.id} className='table-body--row remove-table-body--row' >
                                        <TableCell className='table-body--cell remove-table-body--cell'>
                                            <Checkbox className='player-radio' 
                                                value={player.id} 
                                                checked={removePlayers.includes(player.id)} 
                                                onChange={() => handleRemoveCheckbox(player.id)}
                                            />
                                        </TableCell>
                                        <TableCell className='table-body--cell remove-table-body--cell'>{player.player.name}</TableCell>
                                        <TableCell className='table-body--cell remove-table-body--cell'>{player.player.surname}</TableCell>
                                        <TableCell align="right" className='table-body--cell remove-table-body--cell'>{player.level}</TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table> :
                        <div className='no-players'>
                            You don't have any player to remove    
                        </div>}
                        </Modal.Body>
                        <Modal.Footer className='remove-footer'>
                            <button className='btn-orange confirm-btn' onClick={handleRemove}>Confirm</button>
                            <button className='btn-blue cancel-btn' onClick={() => handleCloseCheckboxModal('remove')}>Cancel</button>
                        </Modal.Footer>
                    </Modal>
            </div>
        )
    } else {
        return <></>
    }
    
}