import React, { useEffect, useState } from 'react'
import { IRankRequirements, IUser } from '../../../shared/interfaces'


export const CarouselContent = ({users, rankName, subRanks, userId}: {users: IUser[],  rankName: string, subRanks: IRankRequirements[], userId: string}) => {
    const [sortedUsers, setSortedUsers] = useState<IUser[]>([])
    
    useEffect(() => {
        const sorting = () => {
            const sorted = users.filter(x => x.userDetail.rankPoints <= (rankName !== 'Grand Champion' ? subRanks[2].pointsLimit : subRanks[0].pointsLimit) && 
                x.userDetail.rankPoints > subRanks[0].pointsRequired)
                .sort((a, b) => { 
                return (a.userDetail.rankPoints > b.userDetail.rankPoints ? -1 : 1) || 
                        a.userDetail.rankPoints.toString().localeCompare(b.userDetail.rankPoints.toString());
                })
            setSortedUsers(sorted)
        }
        sorting()
    }, [])

    return(
        <div className='rank-content'>
            <div className='rank-name'>{rankName}</div>
            {subRanks.map((subRank: IRankRequirements, index) => {
                let digit = ''
                index === 0 ? digit='I' : index === 1 ? digit='II' : digit='III'
                const isEmpty = sortedUsers.filter(x => x.userDetail.rankPoints <= subRank.pointsLimit && x.userDetail.rankPoints > subRank.pointsRequired).length === 0
                return (
                    <div key={subRank.id} className={rankName !== 'Grand Champion' ? 'sub-rank-content' : 'sub-rank-content grand-champion'}>
                        {rankName !== 'Grand Champion' ?
                            <div className='sub-rank-name' >
                                {`${rankName} ${digit}`}  
                                <img src={subRanks.find(x =>x.rankName.includes('1'))?.iconPath!} width={15} height={15}/>
                            </div>
                        : ''}
                        <div className={rankName !== 'Grand Champion' ? 'user-content' : 'user-content grand-champion'} style={isEmpty ? {backgroundColor: 'transparent'}: {}}>
                            {!isEmpty ? 
                            sortedUsers.filter(x => x.userDetail.rankPoints <= subRank.pointsLimit && x.userDetail.rankPoints > subRank.pointsRequired).map((user: IUser, index) => 
                                (
                                    <div key={user.id} className='user-row' style={user.id === userId ? {backgroundColor: '#205281'} : {}}>
                                        <div className='user-index'>{index + 1}.</div>
                                        <div className='user-club-name'>{user.clubName}</div>
                                        <div className='user-rank-points'>{user.userDetail.rankPoints} lp</div>
                                    </div>
                                )
                            ):
                            <div className='no-rank-players'>
                                There's no players in this rank.
                            </div>
                            }
                        </div>
                    </div>
                )
            })}
        </div>
    )
}