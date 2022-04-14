import React, { useEffect, useState } from "react";
import { Radio, Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import { IUser, IUsersPlayer } from "../../../shared/interfaces";
import './style.scss'
import '../../../utils/listTemplate.scss'
import '../../../utils/buttonStyle.scss'
import { Alert, Modal } from 'react-bootstrap'
import { MdModelTraining } from 'react-icons/md'
import { ImCancelCircle } from 'react-icons/im'
import { BsQuestionCircle } from 'react-icons/bs'
import { BiSun } from 'react-icons/bi'
import axios from "axios";

interface option {
    userPlayerId: number,
    trainingType: string,
}

export const Training = ({user}: {user: IUser}) => {
    const players = user.usersPlayers.slice(0).sort((a, b) => { 
        return (a.level > b.level ? -1 : 1) || a.level.toString().localeCompare(b.level.toString());
    })
    const [showModal, setShowModal] = useState(false)
    const [selectedOption, setSelectedOption] = useState<option[]>([])
    const [isValueChanged, setIsValueChanged] = useState(false)
    const [isError, setIsError] = useState(false)
    const [isSuccess, setIsSuccess] = useState(false)

    useEffect(() => {
        const get = () => {
            players.map((player: IUsersPlayer) => {
                setSelectedOption(old => [...old, {userPlayerId: player.id, trainingType: `${player.id}-${player.trainingType}`}])
            })
        }

        get()
    }, [])

    const handleCloseModal = () => setShowModal(false)

    const onChangeSetValue = (e: any, playerId: number) => {
        const player = user.usersPlayers.find(x => x.id === playerId)
        const getOption = (option: string) => {
            if (option.includes('Light')) return 'Light'
            else if (option.includes('Medium')) return 'Medium'
            else if (option.includes('Hard')) return 'Hard'
            else return ''
        }
        let conditionRequired = 0

        switch(getOption(e.target.value)) {
            case 'Light':
                conditionRequired = 1
                break;
            case 'Medium':
                conditionRequired = 2
                break;
            case 'Hard':
                conditionRequired = 4
                break;
        }
        if (player?.condition! < conditionRequired) {
            setIsError(true)
            window.setTimeout(() => {
                setIsError(false)
            }, 1500)
        } else {
            const optionValue = e.target.value
            const optionIndex = selectedOption.findIndex((x => x.userPlayerId == playerId))
    
            selectedOption[optionIndex].trainingType = optionValue
    
            if (!isValueChanged) setIsValueChanged(true)
        } 
    }

    const getObj = (playerId: number) => {
        return selectedOption.find(x => x.userPlayerId == playerId)
    }

    const updateTrainingType = async () => {
        const userId = user.id
        const userPlayersOption = new Array<option>()

        selectedOption.map((option: option) => {
            userPlayersOption.push({
                userPlayerId: option.userPlayerId,
                trainingType: option.trainingType.substring(option.trainingType.indexOf('-') + 1)
            })
        })
        console.log({userId, userPlayersOption})
        let response
        await axios.put('https://localhost:44326/api/Player/updatetraining', {userId, userPlayersOption})
        .then(res => response = res.data)
        .catch(error => console.log(error))

        if (response === 'success') {
            setIsSuccess(true)
                window.setTimeout(() => {
                    setIsSuccess(false)
                }, 1000)
        }
    }

    const clickTest = () => {
        console.log(selectedOption)
        console.log(user)
    }

    return(
        <div className="training-container">
             <Alert variant='success' className='alert training-alert'  show={isSuccess}> 
                    <Alert.Heading className='alert-header'>Changed successfully!</Alert.Heading>
                </Alert>
            <Alert variant='danger' className='alert training-alert'  show={isError}> 
                <Alert.Heading className='alert-header'>This player has not enough condition to do this action!</Alert.Heading>
            </Alert> 
            <div className="table-container training-table-container">
                <Table size="small" className='table training-table'>
                    <TableHead className='table-head training-table-head'>
                        <TableRow className='table-head--row training-table-head--row'>
                            <TableCell 
                                align='center'
                                className='table-head--cell training-table-head--cell name'
                                onClick={clickTest}
                            >
                                Name
                            </TableCell>
                            <TableCell 
                                align='center'
                                className='table-head--cell training-table-head--cell level'
                            >
                                Lvl
                            </TableCell>
                            <TableCell 
                                align="right" 
                                className='table-head--cell training-table-head--cell condition'
                            >
                                Condition
                            </TableCell>
                            <TableCell 
                                align='center'
                                className='table-head--cell training-table-head--cell training'
                            >
                                Training Type
                            </TableCell>

                        </TableRow>
                    </TableHead>
                    <TableBody className='table-body training-table-body'>
                        {players.map((player: IUsersPlayer) => (
                            <TableRow key={player.id} className='table-body--row training-table-body--row'>
                            <TableCell align='center' className='table-body--cell training-table-body--cell name'>{player.player.name} {player.player.surname}</TableCell>
                            <TableCell align='center' className='table-body--cell training-table-body--cell level'>{player.level}</TableCell>
                            <TableCell align='center' className='table-body--cell training-table-body--cell condition'>{player.condition}</TableCell>
                            <TableCell align="center" className='table-body--cell training-table-body--cell icon'>
                                <div className="icon-container">
                                    <Radio className='player-radio' 
                                        value={`${player.id}-Light`}
                                        checked={selectedOption.find(x => x.userPlayerId === player.id)?.trainingType === `${player.id}-Light`} 
                                        onChange={(e: any) => onChangeSetValue(e, player.id)}
                                        icon={<MdModelTraining className="light"/>}
                                        checkedIcon={<MdModelTraining className="light"/>}
                                    />
                                </div> 
                            </TableCell>
                            <TableCell align="center" className='table-body--cell training-table-body--cell icon'>
                                <div className="icon-container">
                                    <Radio className='player-radio' 
                                        value={`${player.id}-Medium`}
                                        checked={getObj(player.id)?.trainingType === `${player.id}-Medium`}
                                        onChange={(e: any) => onChangeSetValue(e, player.id)}
                                        icon={<MdModelTraining className="medium"/>}
                                        checkedIcon={<MdModelTraining className="medium"/>}
                                    />
                                </div>
                            </TableCell>
                            <TableCell align="center" className='table-body--cell training-table-body--cell icon'>
                                <div className="icon-container">
                                    <Radio className='player-radio' 
                                        value={`${player.id}-Hard`}
                                        checked={getObj(player.id)?.trainingType === `${player.id}-Hard`}
                                        onChange={(e: any) => onChangeSetValue(e, player.id)}
                                        icon={<MdModelTraining className="hard"/>}
                                        checkedIcon={<MdModelTraining className="hard"/>}
                                    />
                                </div>
                            </TableCell>
                            <TableCell align="center" className='table-body--cell training-table-body--cell icon'>
                                <div className="icon-container">
                                    <Radio className='player-radio' 
                                        value={`${player.id}-Rest`}
                                        checked={getObj(player.id)?.trainingType === `${player.id}-Rest`}
                                        onChange={(e: any) => onChangeSetValue(e, player.id)}
                                        icon={<BiSun className="rest"/>}
                                        checkedIcon={<BiSun className="rest"/>}
                                    />
                                </div>
                            </TableCell>
                            <TableCell align="center" className='table-body--cell training-table-body--cell icon'>
                                <div className="icon-container">
                                    <Radio className='player-radio' 
                                        value={`${player.id}-None`}
                                        checked={getObj(player.id)?.trainingType === `${player.id}-None`}
                                        onChange={(e: any) => onChangeSetValue(e, player.id)}
                                        icon={<ImCancelCircle className="none"/>}
                                        checkedIcon={<ImCancelCircle className="none"/>}
                                    />
                                </div>
                            </TableCell>
                        </TableRow>
                        ))}
                        
                    </TableBody>
                </Table>
            </div>
            <div className="footer">
                <div className="info-icon" onClick={() => setShowModal(true)}>
                    <BsQuestionCircle />
                </div>
                {isValueChanged ? 
                <button className="btn-orange save" onClick={updateTrainingType}>Save</button>
                : ''}
            </div>
            <Modal dialogClassName='training-info-modal' show={showModal} onHide={handleCloseModal}>
                <Modal.Header className='training-modal-header'>
                    Training
                </Modal.Header>
                <Modal.Body className='training-modal-body'>
                    <div>
                        <span>There's three types of training:</span>
                        <div>- Light</div>
                        <div>- Medium </div>
                        <div>- Hard</div>
                        <div style={{fontSize: 13, marginTop: '10px'}}>
                            <div>Light training gives your player +10 exp.</div>
                            <div style={{marginBottom: '2px'}}>Consumes 1 condition.</div>
                            <div>Medium training gives your player +20 exp.</div>
                            <div style={{marginBottom: '2px'}}>Consumes 2 condition.</div>
                            <div>Hard training gives your player +50 exp.</div>
                            <div>Consumes 4 condition.</div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </div>
    )
}
