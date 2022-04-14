import react, { useState } from 'react'
import Title from '../../../shared/Title';
import { IUser, IUsersPlayer } from '../../../shared/interfaces';
import { DragDropContext } from 'react-beautiful-dnd';
import './style.scss'
import '../../../utils/listTemplate.scss'
import { reorderPlayers } from './reorder';
import { CaptainMap, PlayersListMap } from '../../../shared/types';
import { PlayerLists } from './PlayerLists';
import axios from 'axios';
import { Table, TableCell, TableHead, TableRow } from '@mui/material';
import { Alert, Button, Form, Modal } from 'react-bootstrap';


export const SquadSettings = ({usersPlayers, user}: {usersPlayers: IUsersPlayer[], user: IUser}) => {
    const [isEdited, setIsEdited] = useState(false)
    const [selectValue, setSelectValue] = useState('')
    const [isSuccess, setIsSuccess] = useState(false)
    const [isError, setIsError] = useState(false)
    const [clickedUser, setClickedUser] = useState<IUsersPlayer>()
    const [show, setShow] = useState(false)
    const [alertMessage, setAlertMessage] = useState('')
    const [contractsCount, setContractsCount] = useState<number>()
    let contracts = user.usersItems.find(x=> x.item.name === 'Contracts' )
    let options = new Array<CaptainMap>()

    usersPlayers.sort((a,b) => a.player.name > b.player.name ? 1 : -1).forEach((player: IUsersPlayer) => {
        if (!player.usersPlayerState.isCaptain) {
            let pName = `${player.player.name} ${player.player.surname}`
            options.push({id: player.id, name: pName})
        }
    })

    const [playersMap, setPlayersMap] = useState<PlayersListMap>({
        squad: usersPlayers.filter(x=> x.usersPlayerState.isPlaying === true),
        bench: usersPlayers.filter(x=> x.usersPlayerState.isOnBench === true),
        restPlayers: usersPlayers.filter(x=> x.usersPlayerState.isPlaying === false && x.usersPlayerState.isOnBench === false)
      });

    const onClickSaveChanges = async () => {

        const squad  = playersMap['squad']
        let squadIds: Array<number> = []
        squad.forEach(player => {
            squadIds.push(player.id)
        });

        if (squadIds.length > 5){
            setAlertMessage('Cannot have more than five players in squad')
            setIsError(true)
        } else {
            let c = squad.filter(x => x.player.position === "C").length
            let pg = squad.filter(x => x.player.position === "PG").length
            let sg = squad.filter(x => x.player.position === "SG").length
            let sf = squad.filter(x => x.player.position === "SF").length
            let pf = squad.filter(x => x.player.position === "PF").length
            console.log(c,pg,sg,sf,pf)
            if (c > 1 || pg > 1 || sg > 1 || sf > 1 || pf > 1) {
                setAlertMessage('Cannot be more than 1 player at one position')
                setIsError(true)
            } else {
                const bench  = playersMap['bench']
                let benchIds: Array<number> = []
                bench.forEach(player => {
                    benchIds.push(player.id)
                });

                if (benchIds.length > 7) {
                    setAlertMessage('Cannot have more than seven players on bench')
                    setIsError(true)
                } else {
                    const restPlayers  = playersMap['restPlayers']
                    let restPlayersIds: Array<number> = []
                    restPlayers.forEach(player => {
                        restPlayersIds.push(player.id)
                    });
            
                    let captainId: string = ''
                    captainId = selectValue
            
                    const data = {squadIds, benchIds, restPlayersIds, captainId}
                    await axios.put('https://localhost:44326/api/Player/editSquad', data)
                        .catch(error => console.log(error))

                    setIsSuccess(true)
                    window.setTimeout(() => {
                        window.location.reload()
                    }, 600)
                }
            }
        }
    }

    const handleKeypress = (e: any) => {
        //it triggers by pressing the enter key
      if (e.code === 'Enter' || e.code === "NumpadEnter") {
        onClickSaveChanges();
      }
    };

    const selectChangeHandler = (event: any) => {
        const value = event.currentTarget.value 
        setSelectValue(value)
        setIsEdited(true)
        console.log(selectValue)
    }

    const handleShowModal = (playerId: number) => {
        setShow(true)
        const player = usersPlayers.find(x => x.id === playerId)
        setClickedUser(player)
    }

    const handleCloseModal = () => setShow(false)

    const handleInput = (e: any) => {
        const value = e.target.value
        setContractsCount(value)
    }

    const onClickExtendContracts = async () => {
        let count = contractsCount!
        if(count != 0 && count != undefined) {
            let userItemId = contracts?.id!
            let userPlayerId = clickedUser?.id!
    
            const data = {count, userItemId, userPlayerId}
            let response = ''
    
            await axios.put('https://localhost:44326/api/Item/extendcontract', data)
                .then(res => response = res.data)
                .catch(error => console.log(error))
            console.log(response)
    
            setShow(false)
            setIsSuccess(true)
            window.setTimeout(() => {
                window.location.reload()
            }, 600)
            
        } else {
            window.location.reload()
            setIsError(true)
            setAlertMessage('Cannot extend nothing!')
        }
    }

    return(
        <div className='squad-settings-container'>
            {isSuccess ? 
                <Alert variant='success' className='success-alert alert'  show={isSuccess}> 
                    <Alert.Heading className='alert-header'>Changed successfully </Alert.Heading>
                </Alert> 
            : '' }
            {isError ? 
                <Alert variant='danger' className='danger-alert alert'  show={isError}> 
                    <Alert.Heading className='alert-header'>{alertMessage}</Alert.Heading>
                    <Button className='alert-button' onClick={() => setIsError(false)} variant="outline-danger">
                        Close
                    </Button>
                </Alert> 
            : '' }
            <div className='tables-wrapper'>
                <DragDropContext onDragEnd={({ destination, source }) => {
                    if (!destination) {
                        return;
                    }
                    setPlayersMap(reorderPlayers(playersMap, source, destination));
                    if (source.droppableId !== destination.droppableId) {
                        setIsEdited(true)
                    }
                }}>
                    {Object.entries(playersMap).map(([k, v]) => {
                        let title = ''
                        if (k === 'squad') title = 'Squad'
                        if (k === 'bench') title = 'Bench'
                        if (k === 'restPlayers') title = 'Players'

                        return (
                            <div className={`object-wrapper ${k}-wrapper`} key={k}>
                                <Title className='title'>{title}</Title>
                                <Table className='table-header' >
                                    <TableHead className='header-head'>
                                        <TableRow className='header-head--row'>
                                            <TableCell style={{paddingLeft: '18px', paddingRight: '0'}} className='header-head--cell'>Lvl</TableCell>
                                            <TableCell align='center' style={{paddingLeft: '60px', paddingRight: '0'}} className='header-head--cell'>Name</TableCell>
                                            <TableCell align='right' style={{paddingLeft: '35px', paddingRight: '20px'}} className='header-head--cell'>POS</TableCell>
                                            <TableCell align='left' style={{paddingLeft: '0', paddingRight: '0'}} className='header-head--cell'>CNT</TableCell>
                                        </TableRow>
                                    </TableHead>
                                </Table>    
                                <div className='table-container'>
                                    <PlayerLists
                                    internalScroll
                                    key={k}
                                    listId={k}
                                    listType="CARD"
                                    players={v}
                                    parentCallBack={handleShowModal}
                                    />
                                </div>
                            </div>
                        )
                    })}
                </DragDropContext>
                <div className='select-captain'>
                    <Form.Select
                        className='select-form'
                        placeholder="Select captain"
                        name="country"
                        onChange={ e => selectChangeHandler(e) }
                        value={selectValue}
                    >
                        <option value="" disabled hidden>Select captain</option>
                        {options.map((option: CaptainMap) => (
                            <option key={option.id} value={option.id}>
                                {option.name}
                            </option>
                        ))}
                    </Form.Select>
                </div>
                {isEdited ? <div className='footer'>
                    <button onClick={onClickSaveChanges} onKeyPress={handleKeypress} className='btn-orange save-button'>Save</button>
                </div> : ''}
            </div>
            <Modal className='popup-container' show={show} onHide={handleCloseModal}>
                <Modal.Header className='popup-header' closeButton>
                    <Modal.Title className='popup-title'>{clickedUser?.player.name} {clickedUser?.player.surname}</Modal.Title>
                </Modal.Header>
                <Modal.Body className='popup-body'>
                    <div className='body-content'>
                        <div className='note'>
                        This player have <span style={clickedUser?.contract! > 5 ? {fontWeight: 'bold'} : {fontWeight: 'bold', color: 'red'}}>{clickedUser?.contract}</span> contracts. That means he can play in your
                        team for <span style={{fontWeight: 'bold'}}>{clickedUser?.contract}</span> weeks. If you want to extend his contract, choose below
                        how many weeks do you want to extend contract.
                        </div>
                        <div className='contract-container'>
                            <div className='icon-count'>
                                <img src='https://localhost:44326/images/shopIcons/contract.png' />
                                {contracts?.count!}
                            </div>
                            <div className='add-contracts'>
                                <Form.Control
                                    className='input-number'
                                    type='number'
                                    min='0'
                                    max={contracts?.count!}
                                    size='sm'
                                    placeholder='Contracts'
                                    onChange={ e => handleInput(e) }
                                />
                            </div>
                            <div className='save'>
                                <button className='btn-blue extend-btn' onClick={onClickExtendContracts}>Extend</button>
                            </div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </div>
    )
}