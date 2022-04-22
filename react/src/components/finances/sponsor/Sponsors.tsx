import axios from 'axios'
import React, { useEffect, useState } from 'react'
import './style.scss'
import '../../../utils/buttonStyle.scss'
import { Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import { Modal } from 'react-bootstrap'
import { ISponsor, IUser, IUsersPlayer, IUserSponsor } from '../../../shared/interfaces'
import { BsQuestionCircle } from 'react-icons/bs'
import Alert from 'react-bootstrap/esm/Alert';


export const Sponsors = ({user}:{user: IUser}) => {
    const [sponsor, setSponsor] = useState<IUserSponsor>()
    const [sponsorList, setSponsorList] = useState<ISponsor[]>([])
    const [isSuccess, setIsSuccess] = useState(false)
    const [show, setShow] = useState(false)
    const [squadLevel, setSquadLevel] = useState(0)

    useEffect(() => {
        const getSponsors = async () => {
            await axios.get<ISponsor[]>('https://localhost:44326/api/sponsor')
                .then(res => setSponsorList(res.data))
                .catch(error => console.log(error))

                if (user.userSponsor.sponsor !== null) { setSponsor(user.userSponsor) }
            let squadLvl = 0
            user.usersPlayers.filter(x=> x.usersPlayerState.isPlaying == true).map((userPlayer: IUsersPlayer) => {
                squadLvl += userPlayer.level
            })
            setSquadLevel(squadLvl)
        }

        getSponsors()
    }, [])

    const handleChangeSponsor = async (sponsorId: number) => {
        const userId = user.id
        const data = {userId, sponsorId}

        let apiError: any
        let response: any
        await axios.put('https://localhost:44326/api/sponsor/changesponsor', data)
            .then(res => response = res.data)
            .catch(error => apiError = error)

        if (response === 'success') {
            setIsSuccess(true)
            window.setTimeout(() => {
                window.location.reload()
            }, 600)
        }
    }

    const handleShowModal = () => setShow(true)

    const handleCloseModal = () => setShow(false)

    return(
        <div className='sponsor-container'>
             {isSuccess ? 
                <Alert variant='success' className='success-alert alert'  show={isSuccess}> 
                    <Alert.Heading className='alert-header'>Changed succesfully</Alert.Heading>
                </Alert> 
            : '' }
            {user.userSponsor.sponsor !== null ?
            <div className='current-sponsor-container'>
                <div className='sponsor-name'>
                    <span className='current-sponsor-title'>Current sponsor:</span> {sponsor?.sponsor.name}
                </div> 
                <div className='sponsor-table'>
                    <Table size="small" className='table'>
                        <TableHead className='sponsor-table-head'>
                            <TableRow className='sponsor-table-head--row'>
                                <TableCell align='left' className='sponsor-table-head--cell'></TableCell>
                                <TableCell align='center' className='sponsor-table-head--cell'>
                                    Amount
                                </TableCell>
                                <TableCell align='center' className='sponsor-table-head--cell'>
                                    Count
                                </TableCell>
                                <TableCell align='right' className='sponsor-table-head--cell'>
                                    Totality
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody className='sponsor-table-body'>
                            <TableRow className='sponsor-table-body--row'>
                                <TableCell align='left' className='sponsor-table-body--cell'>Match prize</TableCell>
                                <TableCell align='center' className='sponsor-table-body--cell'>{sponsor?.sponsor.matchPrize}$</TableCell>
                                <TableCell align='center' className='sponsor-table-body--cell'>{sponsor?.matchPrizeCount}</TableCell>
                                <TableCell align='right' className='sponsor-table-body--cell'>{sponsor?.matchPrizeTotality}$</TableCell>
                            </TableRow>
                            <TableRow className='sponsor-table-body--row'>
                                <TableCell align='left' className='sponsor-table-body--cell'>Win prize</TableCell>
                                <TableCell align='center' className='sponsor-table-body--cell'>{sponsor?.sponsor.winPrize}$</TableCell>
                                <TableCell align='center' className='sponsor-table-body--cell'>{sponsor?.winPrizeCount}</TableCell>
                                <TableCell align='right' className='sponsor-table-body--cell'>{sponsor?.winPrizeTotality}$</TableCell>
                            </TableRow>
                            <TableRow className='sponsor-table-body--row'>
                                <TableCell align='left' className='sponsor-table-body--cell'>Title prize</TableCell>
                                <TableCell align='center' className='sponsor-table-body--cell'>{Math.round(sponsor?.sponsor.titlePrize! * user.userDetail.rankPoints / 150)}$</TableCell>
                                <TableCell align='center' className='sponsor-table-body--cell'></TableCell>
                                <TableCell align='right' className='sponsor-table-body--cell'></TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </div>
            </div> 
            :
            <div className='current-sponsor-container no-sponsor-container'>
                <div className='sponsor-name no-sponsor'>
                    <span className='current-sponsor-title'>You have no sponsor yet.</span>
                </div>
            </div>
            }
            <div className='other-sponsors'>
                <div className='table-title'>Other sponsors</div>
                <div className='sponsors-table'>
                    <div className='titles'>
                        <div className='match-prize'>Match prize:</div>
                        <div className='win-prize'>Win prize:</div>
                        <div className='title-prize'>Title prize:</div>
                        <div className='required-level'>Required level:</div>
                    </div>
                    {sponsorList.map((sponsor: ISponsor) => (
                        <div className='sponsor-container' key={sponsor.id}>
                            <div className='name'>{sponsor.name}</div>
                            <div className='match-prize'>{sponsor.matchPrize}$</div>
                            <div className='win-prize'>{sponsor.winPrize}$</div>
                            <div className='title-prize'>{Math.round(sponsor.titlePrize * user.userDetail.rankPoints / 120)}$</div>
                            <div className='required-level'>{sponsor.requiredLevel}lvl</div>
                            <div className='choose-button'>
                                {sponsor.requiredLevel <= squadLevel ? 
                                    <button className='btn-blue' onClick={() => handleChangeSponsor(sponsor.id)}>Choose</button> :
                                    <button className='btn-blue blue-disabled' disabled>Choose</button>}
                            </div>
                        </div>
                    ))}
                </div>
                <div className='info-icon' onClick={handleShowModal}><BsQuestionCircle /></div>
            </div>
            <Modal dialogClassName='sponsor-info-modal' show={show} onHide={handleCloseModal}>
                <Modal.Header className='sponsor-modal-header'>
                    Required level
                </Modal.Header>
                <Modal.Body className='sponsor-modal-body'>
                    <div>
                        Sponsor can be available when your players level who are in the playing squad 
                        is bigger than the required level.
                        Title prize is defined by your rank points.
                    </div>
                    <div style={{ fontSize: 10, marginTop: 10 }}>
                        {`*Total level of squad players >= required level`}
                    </div>
                </Modal.Body>
            </Modal>
        </div>
    )
}