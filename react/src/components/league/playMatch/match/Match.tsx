import axios from 'axios'
import react, { useEffect, useState } from 'react'
import { IBackgroundTask, IUser, IUserMatchesHistory } from '../../../../shared/interfaces'
import { BiCrown } from 'react-icons/bi'
import './style.scss'
import { useNavigate } from 'react-router-dom'


export const Match = ({user}: {user: IUser}) => {
    const [useEffectRender, setUseEffectRender] = useState(false)
    const [actualMatch, setActualMatch] = useState<IUserMatchesHistory>()
    const [isMatchStarted, setIsMatchStarted] = useState(false)
    const [user1Won, setUser1Won] = useState(false)
    const [user2Won, setUser2Won] = useState(false)
    const [timerColor, setTimerColor] = useState('white')
    const [userColor, setUserColor] = useState('white')
    const [userScoreColor, setUserScoreColor] = useState('white')
    const [user2Color, setUser2Color] = useState('white')
    const [user2ScoreColor, setUser2ScoreColor] = useState('white')
    const [minutes, setMinutes] = useState(15)
    const [seconds, setSeconds] = useState(0)
    const navigate = useNavigate()

    const getTime = async () => {
        await axios.get(`https://localhost:44326/api/Match/gettime/${user.id}`)
        .then(res => {
            setMinutes(res.data.minutes)
            setSeconds(res.data.seconds)
        })
    }
    
    useEffect(() => {
        if (!user.isPlaying) navigate('/league/play')
        let interval: any = null;
        interval = setInterval(() => {
        setUseEffectRender(render => !render) // rerender useEffecta co 1s
            if (isMatchStarted) {
                if (minutes != 0 || seconds != 0) {
                    getTime()
                } else {
                    setTimerColor('#ff2d2d')
                    if (actualMatch?.userScore! > actualMatch?.user2Score!) {
                        setUser1Won(true)
                        setUserColor('#dfc221')
                        setUserScoreColor('#16c525')
                        setUser2ScoreColor('#ff2d2d')
                    } else if (actualMatch?.userScore! < actualMatch?.user2Score!) {
                        setUser2Won(true)
                        setUser2Color('#dfc221')
                        setUser2ScoreColor('#16c525')
                        setUserScoreColor('#ff2d2d')
                    }
                }
            }
          }, 1000)

        let opponentId: string

        const getMatch = async () => {
            console.log('getting data')
            const userId = user.id
            await axios.get<IUserMatchesHistory>(`https://localhost:44326/api/Match/actualmatch/${userId}`)
            .then(res => {
                console.log(res.data)
                setActualMatch(res.data)
                opponentId = res.data.user2Id
            })
            .catch(error => console.log(error))

            await axios.get<IBackgroundTask>(`https://localhost:44326/api/Match/matchtask/${userId}`)
                .then(res => setIsMatchStarted(res.data.isStarted))
                .catch(error => console.log(error))
        }

        getMatch()

        return () => clearInterval(interval);
    }, [useEffectRender, minutes, seconds] )

    if (isMatchStarted) {
        return(
            <div className='match-container'>
                <div className='match-table'>
                    <div className='user'>
                        {user1Won ?<div className='crown-icon'><BiCrown /></div> : ''}
                        <div className='club-name' style={{color: userColor} }>{actualMatch?.userClub}</div>
                        <div className='score left-score' style={{color: userScoreColor} }>{actualMatch?.userScore}</div>
                    </div>
                    <div className='dash'>-</div>
                    <div className='user'>
                        <div className='score right-score' style={{color: user2ScoreColor} }>{actualMatch?.user2Score}</div>
                        <div className='club-name' style={{color: user2Color} }>{actualMatch?.user2Club}</div>
                        {user2Won ? <div className='crown-icon'><BiCrown /></div> : ''}
                    </div>
                </div>
                <div className='timer' style={{color: timerColor}}>
                    {minutes < 10 ? '0' + minutes.toString(): minutes}:{seconds < 10 ? '0' + seconds.toString(): seconds}
                </div>
                {minutes == 0 && seconds == 0 ? 
                <div className='match-end'>
                    Match ended!
                </div>
                : ''}
            </div>
        )
    } else {
        return(
            <div className='match-container'>
                <div className='match-loading'>
                    Loading match...
                </div>
            </div>
        )
    }
    
}