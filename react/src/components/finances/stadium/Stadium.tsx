import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Alert, Form, Modal } from 'react-bootstrap'
import { IStadium, IUser } from '../../../shared/interfaces'
import './style.scss'

export const Stadium = ({stadium, user}: {stadium: IStadium, user: IUser}) => {
    const maxStadiumLevel = 5
    const [stadiumPicture, setStadiumPicture] = useState('')
    const [isSuccess, setIsSuccess] = useState(false)
    const [alertMessage, setAlertMessage] = useState('')
    const [show, setShow] = useState(false)
    const [name, setStadiumName] = useState('')

    useEffect(() => {
        const get = () => {
            setStadiumPicture('https://localhost:44326/images/stadium.png')
        }

        get()
    }, [])

    const onClickUpgrade = async () => {
        const stadiumId = stadium.id
        const userId = user.id
        const data = {stadiumId, userId}

        let apiError: any
        let response: any
        await axios.put('https://localhost:44326/api/Stadium/upgrade', data)
            .then(res => response = res.data)
            .catch(error => apiError = error)

        if (response !== 'success') {
            console.log(apiError)
        } else {
            setAlertMessage('Upgraded successfully')
            setIsSuccess(true)
            window.setTimeout(() => {
                window.location.reload()
            }, 600)
        }
    }

    const handleStadiumNameChange = async () => {
        const stadiumId = stadium.id
        const stadiumName = name
        const data = {stadiumId, stadiumName}

        let apiError: any
        await axios.put('https://localhost:44326/api/Stadium/namechange', data)
            .then(res => console.log(res.data))
            .catch(error => apiError = error)

        if (apiError !== undefined) {
            console.log(apiError)
        } else {
            setAlertMessage('Changed successfully')
            setShow(false)
            setIsSuccess(true)
            window.setTimeout(() => {
                window.location.reload()
            }, 600)
        }
    }

    const handleInput = (e: any) => {
        const value = e.target.value
        setStadiumName(value)
        console.log(name)
    }

    const handleCloseModal = () => setShow(false)

    const handleOpenModal = () => setShow(true)

    return(
        <div className='stadium-container'>
            {isSuccess ? 
                <Alert variant='success' className='success-alert alert'  show={isSuccess}> 
                    <Alert.Heading className='alert-header'>{alertMessage}</Alert.Heading>
                </Alert> 
            : '' }
            <div className='stadium-name-container'>
                <button className='stadium-name' onClick={handleOpenModal}> 
                    {stadium.name } 
                </button>
                <div className='icon'>
                    <img className='icon' src='https://localhost:44326/images/edit.png' />
                </div>
            </div>
            <div className='stadium-content'>
                <div className='stadium-picture'>
                    <img src={stadiumPicture} />
                </div>
                <div className='stadium-info'>
                    <div className='info-container'>
                        <div className='label'>
                            Seats capacity:
                        </div>
                        <div className='content'>{stadium.seatsCapacity}</div>
                    </div>
                    <div className='info-container'>
                        <div className='label'>
                            Income per viewer:
                        </div>
                        <div className='content'>{stadium.incomePerViewer}$</div>
                    </div>
                    <div className='info-container'>
                        <div className='label'>
                            Level:
                        </div>
                        <div className='content'>{stadium.level < maxStadiumLevel ? stadium.level : `MAX (${stadium.level}lvl)`}</div>
                    </div>
                    {stadium.level < maxStadiumLevel ?
                    <div className='info-container'>
                        <div className='label'>
                            Upgrade cost:
                        </div>
                        <div className='content'>{stadium.price}$</div>
                    </div>
                    : ''}

                    {stadium.level < maxStadiumLevel ? 
                    <div className='upgrade-button'>
                        {user.money > stadium.price ? 
                            <button className='btn-blue' onClick={onClickUpgrade}>Upgrade</button> :
                            <button className='btn-blue disabled' disabled>Upgrade</button>
                        }
                    </div>
                    : ''}
                </div>
            </div>
            <Modal dialogClassName='stadium-name-modal' show={show} onHide={handleCloseModal}>
                    <Modal.Body className='stadium-name-body'>
                        <div className='body-container'>
                            <div className='input'>
                                <Form.Control 
                                    type='text'
                                    onChange={ e => handleInput(e) }
                                    placeholder='Change name...'    
                                    maxLength={10}
                                />
                            </div>
                            <div className='change-button'>
                                <button className='btn-blue change-btn' onClick={handleStadiumNameChange} >Change</button>
                            </div>
                        </div>
                    </Modal.Body>
                </Modal>
        </div>
        
    )
}