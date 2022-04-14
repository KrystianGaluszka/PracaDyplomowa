import axios from 'axios';
import react, { useEffect, useState } from 'react'
import { Alert, Modal } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import { IUser, IUserMatchesHistory, IUsersPlayer } from '../../../shared/interfaces';
import './style.scss'

export const PlayMatch = ({user}: {user: IUser}) => {
    const [clicked, setClicked] = useState(false)
    const [isAccepted, setIsAccepted] = useState(false)
    const [seconds, setSeconds] = useState(0);
    const [minutes, setMinutes] = useState(0);
    const [timer, setTimer] = useState(3)
    const [isError, setIsError] = useState(false)
    const [errorMessage, setErrorMessage] = useState('')
    const [squadLvl, setSquadLvl] = useState(0)
    const navigate = useNavigate()

    useEffect(() => {
        if (user.isPlaying) {
            navigate('/league/play/match')
        } 
        if (squadLvl === 0) {
            let lvl: number = 0
            user.usersPlayers.filter(x => x.usersPlayerState.isPlaying).map((player: IUsersPlayer) => {
                lvl += player.level
            })
            setSquadLvl(lvl)
        }
        
        if (user.isAccepted) {
            setIsAccepted(true)
            setClicked(false)
            setInterval(() => {
                setTimer(timer - 1)
            }, 1000)
            
            console.log(timer)
        }

        let interval: any = null;
        if (clicked) {
          interval = setInterval(() => {
            if (seconds == 59) {
                setMinutes(minutes => minutes + 1)
                setSeconds(0)
            } else {
                setSeconds(seconds => seconds + 1);
            }
          }, 1000)
        } else if (!clicked && seconds !== 0) {
          clearInterval(interval);
        }
        
        return () => clearInterval(interval);
    }, [clicked, seconds, timer])


    const handleStartQueue = async () => {
        const userId = user.id
        const data = { userId }
        const playersPlaying = user.usersPlayers.filter(x => x.usersPlayerState.isPlaying)

        if (playersPlaying.length < 5) {
            setErrorMessage('You dont have enough players to play match')
            setIsError(true)
            window.setTimeout(() => {
                setIsError(false)
            }, 1500)
        } else if (playersPlaying.filter(x => !x.usersPlayerState.isInjured).length < 5) {
            setErrorMessage('You have at least one injured player')
            setIsError(true)
            window.setTimeout(() => {
                setIsError(false)
            }, 1500)
        } else {
            await axios.put('https://localhost:44326/api/Match/queue', data)
            .then(res => console.log(res.data))
            .catch(error => console.log(error))

        setClicked(true)
        }
    }

    const handleCancelQueue = async () => {
        const userId = user.id
        const data = { userId }

        setSeconds(0)
        setMinutes(0)

        await axios.put('https://localhost:44326/api/Match/cancelqueue', data)
            .then(res => console.log(res.data))
            .catch(error => console.log(error))

        setClicked(false)
    }


    if (user.isAccepted) {
        window.setTimeout(async () => {
            setIsAccepted(false)
            navigate('/league/play/match') // dużo warningów "No routes matched" ok. 50 (to przez ten rerender useEffecta w layoucie)
        }, 3000)
    }

    return(
        <div className='queue-container'>
            <div className='squad-container'>
                <div className='squad-title'>
                    <span>Your squad:</span>
                    <div>{squadLvl} Lvl</div>
                </div>
                {user.usersPlayers.filter(x => x.usersPlayerState.isPlaying).map((player: IUsersPlayer) => {
                    let color = ''
                    switch(player.player.rarity) {    
                        case 'Common':
                            color = 'grey'
                            break;
                        case 'Uncommon':
                            color = '#00dd00'
                            break;
                        case 'Rare':
                            color = '#07dcf8'
                            break;
                        case 'Epic':
                            color = '#cb00dd'
                            break;
                        case 'Masterwork':
                            color = '#dd8500'
                            break;
                        case 'Legendary':
                            color = '#ccc01b'
                            break;
                    }
                    return(
                    <div className='squad-player' key={player.id}>
                        <div className='player-icon'><img src='https://localhost:44326/images/players-icon.png' className='icon' style={{ borderColor: color}}/></div>
                        <div className='player-name'>{player.player.name} {player.player.surname}</div>
                        <div className='player-info'>
                            {player.level} level
                        </div>
                    </div>
                    ) 
                })}
            </div>
            <div className='play-match-container'>
                <Alert variant='danger' className='alert queue-alert'  show={isError}> 
                    <Alert.Heading className='alert-header'>{errorMessage}</Alert.Heading>
                </Alert> 
                <div className='play-button-container'>
                    {clicked ?
                    <div className='cancel'>
                        <div className='timer'>{minutes < 10 ? '0' + minutes.toString(): minutes}:{seconds < 10 ? '0' + seconds.toString(): seconds}</div>
                        <button className='btn-orange cancel-btn' onClick={handleCancelQueue}>Cancel</button>
                    </div>
                    :
                    <div className='play'>
                        <button className='btn-orange' onClick={handleStartQueue}>Play</button>
                    </div> 
                    
                    }
                </div> 
                <Modal dialogClassName='match-found-modal' show={isAccepted} >
                    <Modal.Body className='popup-body match-found-body'>
                        <div>MATCH FOUND!</div>
                        <div>{timer == 0 ? '' : timer}</div>
                    </Modal.Body>
                </Modal>
            </div>
        </div>
    )
}