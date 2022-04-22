import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Carousel } from 'react-bootstrap'
import { IRankRequirements, IUser } from '../../../shared/interfaces'
import { CarouselContent } from './CarouselContent'
import './style.scss'


export const Table = ({user}: {user: IUser}) => {
    const [isLoading, setIsLoading] = useState(true)
    const [allUsers, setAllUsers] = useState<IUser[]>([])
    const [rankRequirements, setRankRequirements] = useState<IRankRequirements[]>([])
    const [activeIndex, setActiveIndex] = useState(0)
    const [rankNames, setRankNames] = useState<string[]>([])

    useEffect(() => {
        const getUsers = async () => {
            await axios.get<IUser[]>('https://localhost:44326/api/User')
                .then(res => {
                    setAllUsers(res.data)
                })
                .catch(error => console.log(error))

            const check = (limitRank: number) => {
                var userRank = user.userDetail.rankPoints
                return (userRank > limitRank)
            }

            await axios.get<IRankRequirements[]>('https://localhost:44326/api/User/ranktable')
                .then(res => {
                    setRankRequirements(res.data)

                    switch(true) {
                        case check(res.data.find(x => x.rankName === 'Champion 3')?.pointsRequired!):
                            setActiveIndex(6)
                            break
                        case check(res.data.find(x => x.rankName === 'Diamond 3')?.pointsRequired!):
                            setActiveIndex(5)
                            break
                        case check(res.data.find(x => x.rankName === 'Platinum 3')?.pointsRequired!):
                            setActiveIndex(4)
                            break
                        case check(res.data.find(x => x.rankName === 'Gold 3')?.pointsRequired!):
                            setActiveIndex(3)
                            break
                        case check(res.data.find(x => x.rankName === 'Silver 3')?.pointsRequired!):
                            setActiveIndex(2)
                            break
                        case check(res.data.find(x => x.rankName === 'Bronze 3')?.pointsRequired!):
                            setActiveIndex(1)
                            break
                    }
                    setRankNames(['Bronze', 'Silver', 'Gold', 'Platinum', 'Diamond', 'Champion', 'Grand Champion'])
                })
                .catch(error => console.log(error))

            setIsLoading(false)
        }
        getUsers()
    }, [])

    if(isLoading) {
        return <></>
    } else {
        return( 
            <div className='league-table-container'>
                <Carousel className='table-carousel-container carousel-control-prev-icon'
                    interval={null} 
                    indicators={false} 
                    defaultActiveIndex={activeIndex} 
                    wrap={false} 
                >
                    {rankNames.map((rankName: string) => (
                        <Carousel.Item className='table-carousel-item' key={rankName}>
                        <CarouselContent 
                            key={rankName}
                            users={allUsers} 
                            userId={user.id}
                            rankName={rankName}
                            subRanks={rankRequirements.filter(x=> x.rankName.includes(rankName))}
                        />
                    </Carousel.Item>            
                    ))}
                </Carousel>
            </div>
        )
    }
}