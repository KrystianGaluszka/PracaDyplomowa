import { useEffect, useState } from 'react';
import Moment from 'moment'
import './style.scss'
import { IUser, IUserMatchesHistory, IUsersPlayer } from '../../shared/interfaces';
import '../../shared/subPageHelper.scss'
import axios from 'axios';
import { BiCrown } from 'react-icons/bi'

export const HomePage = ({user}: {user: IUser}) => {
    const [players, setPlayers] = useState<IUsersPlayer[]>([])
    const [scorePlayer, setScorePlayer] = useState<IUsersPlayer>()
    const [levelPlayer, setLevelPlayer] = useState<IUsersPlayer>()
    const [user1Won, setUser1Won] = useState(false)
    const [user2Won, setUser2Won] = useState(false)
    const [userColor, setUserColor] = useState('white')
    const [userScoreColor, setUserScoreColor] = useState('white')
    const [user2Color, setUser2Color] = useState('white')
    const [user2ScoreColor, setUser2ScoreColor] = useState('white')
    const lastMatch = user.userMatchesHistory[user.userMatchesHistory.length - 1]

    useEffect(() => {
        const getPlayers = async () => {
            await axios.get<IUsersPlayer[]>('https://localhost:44326/api/Player/usersplayers')
                .then(res => {
                    setPlayers(res.data)
                    setScorePlayer(res.data.reduce((max, player) => max.score > player.score ? max : player))
                    setLevelPlayer(res.data.reduce((max, player) => max.level > player.level ? max : player))
                })
        }
        if(lastMatch != null) {
            if (lastMatch.userScore > lastMatch.user2Score) {
                setUser1Won(true)
                setUser2Won(false)
                setUserColor('#dfc221')
                setUserScoreColor('#16c525')
                setUser2ScoreColor('#ff2d2d')
            } else if (lastMatch.userScore < lastMatch.user2Score) {
                setUser1Won(false)
                setUser2Won(true)
                setUser2Color('#dfc221')
                setUser2ScoreColor('#16c525')
                setUserScoreColor('#ff2d2d')
            }
        }

        getPlayers()
    }, [])

    return (
        <div className='homeContainer scrollable'>
            <div className='news-info-container'>
                {user.userMatchesHistory.length !== 0 ?
                    <div className='match-info info-container'>
                        <div className='title'>Your last game</div>
                        <div className='match'>
                            <div className='user left-user'>
                            {user1Won ?<div className='crown-icon'><BiCrown /></div> : ''}
                            <div className='club-name' style={{color: userColor} }>{lastMatch.userClub}</div>
                            <div className='score left-score' style={{color: userScoreColor} }>{lastMatch?.userScore}</div>
                        </div>
                            <div className='dash'>-</div>
                            <div className='user right-user'>
                                <div className='score right-score' style={{color: user2ScoreColor} }>{lastMatch.user2Score}</div>
                                <div className='club-name' style={{color: user2Color} }>{lastMatch.user2Club}</div>
                                {user2Won ? <div className='crown-icon'><BiCrown /></div> : ''}
                            </div>
                        </div>
                    </div>
                : ''}
                <div className='score-info info-container'>
                    <div className='title'>Best player by score this season!</div>
                    <div className='score-container'>
                        <div className='name content'>
                            <span className='content-title'>Name:</span>
                            <span className='content-value'>{scorePlayer?.player.name} {scorePlayer?.player.surname}</span>
                        </div>
                        <div className='club content'>
                            <span className='content-title'>Club:</span>
                            <span className='content-value'>{scorePlayer?.user.clubName}</span>
                        </div>
                        <div className='score content'>
                            <span className='content-title'>Score:</span>
                            <span className='content-value'>{scorePlayer?.score} points</span>
                        </div>
                    </div>
                </div>
                <div className='level-player-info info-container'>
                    <div className='title'>Best player by level this season!</div>
                    <div className='level-player-container'>
                        <div className='name content'>
                            <span className='content-title'>Name:</span>
                            <span className='content-value'>{scorePlayer?.player.name} {scorePlayer?.player.surname}</span>
                        </div>
                        <div className='club content'>
                            <span className='content-title'>Club:</span>
                            <span className='content-value'>{scorePlayer?.user.clubName}</span>
                        </div>
                        <div className='level content'>
                            <span className='content-title'>Level:</span>
                            <span className='content-value'>{levelPlayer?.level} level</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}