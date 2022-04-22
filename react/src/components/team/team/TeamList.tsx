import react, { useEffect, useState } from 'react';
import { Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import { IUser, IUsersPlayer } from '../../../shared/interfaces';
import Title from '../../../shared/Title';
import { Modal } from 'react-bootstrap';
import { ModalRow } from './ModalRow';
import './style.scss'
import '../../../utils/listTemplate.scss'


export const TeamList = ({usersPlayers, user}: {usersPlayers: IUsersPlayer[], user: IUser}) => {
    const [userPlayers, setUserPlayers] = useState<IUsersPlayer[]>([])
    const [show, setShow] = useState(false)
    const [clickedPlayer, setClickedPlayer] = useState<IUsersPlayer>()
    const [rarityColor, setRarityColor] = useState('')
    const [contractIcon, setContractIcon] = useState('')
    const [boostIcon, setBoostIcon] = useState('')
    const [medkitIcon, setMedkitIcon] = useState('')
    const [basketballIcon, setBaskteballIcon] = useState('')
    const [ascSorting, setAscSorting] = useState(true)
    const [squadLevel, setSquadLevel] = useState(0)
    const [teamLevel, setTeamLevel] = useState(0)

    useEffect(() => {
        const getPlayers = async () => {
            setUserPlayers(usersPlayers.sort((a, b) => { 
                return (a.player.name > b.player.name ? 1 : -1) || a.player.name.localeCompare(b.player.name);
            }))
            setContractIcon('https://localhost:44326/images/shopIcons/contract-expiring.png')
            setBoostIcon('https://localhost:44326/images/shopIcons/xp-boost-clear.png')
            setMedkitIcon('https://localhost:44326/images/shopIcons/med-kit-clear.png')
            setBaskteballIcon('https://localhost:44326/images/basketball.png')

            let teamLvl = 0
            let squadLvl = 0
            user.usersPlayers.map((player: IUsersPlayer) => {
                if (player.usersPlayerState.isPlaying) squadLvl += player.level
                teamLvl += player.level
            })
            setSquadLevel(squadLvl)
            setTeamLevel(teamLvl)
        }

        getPlayers()
    }, [])

    const handleShowModal = (userPlayerId: number) => {
        setShow(true)
        const sourcePlayer = userPlayers.find(x => x.id === userPlayerId)
        const playerDeepCopy = JSON.parse(JSON.stringify(sourcePlayer)) 
        

        switch(sourcePlayer?.player.rarity) {
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

        switch(sourcePlayer?.player.position) {
            case 'C':
                playerDeepCopy.player.position = 'Center'
                break
            case 'PG':
                playerDeepCopy.player.position = 'Point Guard'
                break
            case 'SG':
                playerDeepCopy.player.position = 'Shooting Guard'
                break
            case 'SF':
                playerDeepCopy.player.position = 'Small Forward'
                break
            case 'PF':
                playerDeepCopy.player.position = 'Power Forward'
                break
            
        }
        setClickedPlayer(playerDeepCopy)
    }

    const handleCloseModal = () => setShow(false)

    const handleAscSort = (sortBy: string) => {
        setAscSorting(false)

        switch(sortBy) {
            case 'name':
                const nameSorted = userPlayers.slice(0).sort((a, b) => { 
                    return (a.player.name > b.player.name ? 1 : -1) || a.player.name.localeCompare(b.player.name);
                })
                setUserPlayers(nameSorted)
                break
            case 'surname':
                const surnameSorted = userPlayers.slice(0).sort((a, b) => { 
                    return (a.player.surname > b.player.surname ? 1 : -1) || a.player.surname.localeCompare(b.player.surname);
                })
                setUserPlayers(surnameSorted)
                break
            case 'country':
                const countrySorted = userPlayers.slice(0).sort((a, b) => { 
                    return (a.player.country > b.player.country ? 1 : -1) || a.player.country.localeCompare(b.player.country);
                })
                setUserPlayers(countrySorted)
                break
            case 'level':
                const lvlSorted = userPlayers.slice(0).sort((a, b) => { 
                    return (a.level > b.level ? 1 : -1) || a.level.toString().localeCompare(b.level.toString());
                })
                setUserPlayers(lvlSorted)
                break
        }
    }

    const handleDescSort = (sortBy: string) => {
        setAscSorting(true)

        switch(sortBy) {
            case 'name':
                const nameSorted = userPlayers.slice(0).sort((a, b) => { 
                    return (a.player.name > b.player.name ? -1 : 1) || a.player.name.localeCompare(b.player.name);
                })
                setUserPlayers(nameSorted)
                break
            case 'surname':
                const surnameSorted = userPlayers.slice(0).sort((a, b) => { 
                    return (a.player.surname > b.player.surname ? -1 : 1) || a.player.surname.localeCompare(b.player.surname);
                })
                setUserPlayers(surnameSorted)
                break
            case 'country':
                const countrySorted = userPlayers.slice(0).sort((a, b) => { 
                    return (a.player.country > b.player.country ? -1 : 1) || a.player.country.localeCompare(b.player.country);
                })
                setUserPlayers(countrySorted)
                break
            case 'level':
                const lvlSorted = userPlayers.slice(0).sort((a, b) => { 
                    return (a.level > b.level ? -1 : 1) || a.level.toString().localeCompare(b.level.toString());
                })
                setUserPlayers(lvlSorted)
                break
        }
    }
    
    return (
        <div className='team-list-container'>
            <div className='info-card'>
                <div className='card-icon'>
                    <img src={basketballIcon} />
                </div>
                <div className='card-content'>
                    <div className='card-content--content content-title'>
                        <div>Team:</div>
                        <div>Squad level:</div>
                        <div>Team level:</div>
                    </div>
                    <div className='card-content--content content-info'>
                        <div>{user.clubName}</div>
                        <div>{squadLevel}</div>
                        <div>{teamLevel}</div>
                    </div>
                </div>
            </div>
            <div className='table-container'>
                <Table size="small" className='table'>
                    <TableHead className='table-head'>
                        <TableRow className='table-head--row'>
                            <TableCell align='left'className='table-head--cell playerIcon'></TableCell>
                            <TableCell 
                                align='center'
                                className='table-head--cell click' 
                                onClick={() => ascSorting? handleAscSort('name') : handleDescSort('name')}
                            >
                                Name
                            </TableCell>
                            <TableCell 
                                align='center'
                                className='table-head--cell click' 
                                onClick={() => ascSorting? handleAscSort('surname') : handleDescSort('surname')}
                            >
                                Surname
                            </TableCell>
                            <TableCell 
                                align='center'
                                className='table-head--cell click country' 
                                onClick={() => ascSorting? handleAscSort('country') : handleDescSort('country')}
                            >
                                Country
                            </TableCell>
                            <TableCell align='center' className='table-head--cell click position'>POS</TableCell>
                            <TableCell className='table-head--cell icon-head'></TableCell>
                            <TableCell className='table-head--cell icon-head'></TableCell>
                            <TableCell className='table-head--cell icon-head'></TableCell>
                            <TableCell 
                                align="right" 
                                className='table-head--cell level click' 
                                onClick={() => ascSorting? handleAscSort('level') : handleDescSort('level')}
                            >
                                Level
                            </TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody className='table-body'>
                        {userPlayers.map((player: IUsersPlayer) => {
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
                        return (
                            <TableRow key={player.id} className='table-body--row' onClick={() => handleShowModal(player.id)}>
                                <TableCell className='table-body--cell playerIcon'><img alt='playerIcon' src={player.player.picturePath} style={{ borderColor: color}}/></TableCell>
                                <TableCell align='center' className='table-body--cell click'>{player.player.name}</TableCell>
                                <TableCell align='center' className='table-body--cell click'>{player.player.surname}</TableCell>
                                <TableCell align='center' className='table-body--cell click'>{player.player.country}</TableCell>
                                <TableCell align='center' className='table-body--cell click'>{player.player.position}</TableCell>
                                <TableCell align="right" className='table-body--cell icon'>{player.usersPlayerState.isBoosted ? <img alt='boostIcon' src={boostIcon} /> : ''}</TableCell>
                                <TableCell align="right" className='table-body--cell icon'>{player.usersPlayerState.isInjured ? <img alt='medkitIcon' src={medkitIcon} /> : ''}</TableCell>
                                <TableCell align="right" className='table-body--cell icon'>{player.contract <= 5 ? <img alt='contractIcon' src={contractIcon} /> : ''}</TableCell>
                                <TableCell align="right" className='table-body--cell '>{player.level}</TableCell>
                            </TableRow>
                        )})}
                    </TableBody>
                </Table>

                <Modal dialogClassName='team-list-modal' show={show} onHide={handleCloseModal}>
                    <Modal.Header className='popup-header'>
                        <Modal.Title className='popup-title'>{clickedPlayer?.player.name} {clickedPlayer?.player.surname}</Modal.Title>
                        <div className='modal-icons'>
                            <div className='boost-icon'>{clickedPlayer?.usersPlayerState.isBoosted ? <img alt='boostIcon' src={boostIcon} /> : ''}</div>
                            <div className='medkit-icon'>{clickedPlayer?.usersPlayerState.isInjured ? <img alt='medkitIcon' src={medkitIcon} /> : ''}</div>
                            <div className='contract-icon'>{clickedPlayer?.contract! <= 5 ? <img alt='contractIcon' src={contractIcon} /> : ''}</div>
                        </div>
                    </Modal.Header>
                    <Modal.Body className='popup-body'>
                        <div className='body-content'>
                            <ModalRow title='Weight' content={`${clickedPlayer?.player.weight!} kg`}/>
                            <hr/>
                            <ModalRow title="Height" content={`${clickedPlayer?.player.height!} cm`} />
                            <hr/>
                            <ModalRow title="Country" content={clickedPlayer?.player.country!} />
                            <hr/>
                            <ModalRow title="Club" content={clickedPlayer?.player.club!} />
                            <hr/>
                            <ModalRow title="League" content={clickedPlayer?.player.league!} />
                            <hr/>
                            <ModalRow title="Level" content={clickedPlayer?.level!} />
                            <hr/>
                            <ModalRow title="Experience" content={`${clickedPlayer?.experience!} / ${clickedPlayer?.requiredExperience!}`} />
                            <hr/>
                            <ModalRow title="Score" content={`${clickedPlayer?.score!} p.`} />
                            <hr/>
                            <ModalRow title="Position" content={clickedPlayer?.player.position!} />
                            <hr/>
                            <ModalRow title="Rarity" color={rarityColor} content={clickedPlayer?.player.rarity!} />
                            <hr/>
                            <ModalRow title="Condition" content={`${(clickedPlayer?.condition!)}%`} />
                            <hr/>
                            <ModalRow title="Contracts" content={clickedPlayer?.contract!} />
                            <hr/>
                            <ModalRow title="Salary" content={clickedPlayer?.salary!} />
                        </div>
                    </Modal.Body>
                </Modal>
            </div>
        </div>
    )
}