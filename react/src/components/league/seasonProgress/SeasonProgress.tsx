import react, { useEffect } from 'react'
import { IUser } from '../../../shared/interfaces'
import { ApexOptions } from 'apexcharts'
import ReactApexChart from 'react-apexcharts'
import './style.scss'
import { useState } from 'react'
import axios from 'axios'

interface IChartData {
    series: Array<any>,
    options: ApexOptions,
}

export const SeasonProgress = ({user}: {user: IUser}) => {
    const [teamsAvgWins, setTeamsAvgWins] = useState<number>(0)
    const [teamsAvgLost, setTeamsAvgLost] = useState<number>(0)

    useEffect(() => {
        const getPlayers = async () => {
            await axios.get<IUser[]>('https://localhost:44326/api/User')
                .then(res => {
                    let wins = 0
                    let loses = 0

                    res.data.forEach((user: IUser) => {
                        wins += user.userDetail.matchesWon
                        loses += user.userDetail.matchesLost
                    })
                    setTeamsAvgWins(wins / res.data.length)
                    setTeamsAvgLost(loses / res.data.length)
                })
                .catch(error => console.log(error))
        }

        getPlayers()
    }, [])

    const matchesData: IChartData = {
        series: [user.userDetail.matchesLost, user.userDetail.matchesWon, user.userDetail.matchesDrawn],
        options: {
            chart: {
                type: 'donut'
            },
            labels: ['Matches Lost', 'Matches Won', 'Matches Drawn'],
            legend: {
                position: 'bottom',
            },
        },
    }

    const allMatchesData: IChartData = {
        series: [user.userDetail.allMatchesLost, user.userDetail.allMatchesWon, user.userDetail.allMatchesDrawn],
        options: {
            chart: {
                type: 'donut'
            },
            labels: ['All Matches Lost', 'All Matches Won', 'All Matches Drawn'],
            legend: {
                position: 'bottom',
            },
        },
    }

    const avgWins: IChartData = {
        series: [user.userDetail.matchesWon, teamsAvgWins],
        options: {
            chart: {
                type: 'donut'
            },
            labels: ['Your wins', 'Average team wins'],
            legend: {
                position: 'bottom',
            },
        },
    }

    const avgLoses: IChartData = {
        series: [user.userDetail.matchesLost, teamsAvgLost],
        options: {
            chart: {
                type: 'donut'
            },
            labels: ['Your loses', 'Average team loses'],
            legend: {
                position: 'bottom',
            },
        },
    }

    return (
        <div className='season-progress-container'>
            <div className='charts-container'>
                <div className='matches-chart-container'>
                    <div className='chart-title'>Season</div>
                    <ReactApexChart type='donut' options={matchesData.options} series={matchesData.series} className='matches-chart left'/>
                </div>
                <div className='matches-chart-container'>
                    <div className='chart-title'>Overall</div>
                    <ReactApexChart type='donut' options={allMatchesData.options} series={allMatchesData.series} className='matches-chart right'/>
                </div>
            </div>
            <div className='charts-container second-chart-container'>
                <div className='matches-chart-container second-matches-container'>
                    <div className='chart-title'>Wins</div>
                    <ReactApexChart type='donut' options={avgWins.options} series={avgWins.series} className='matches-chart left'/>
                </div>
                <div className='matches-chart-container second-matches-container'>
                    <div className='chart-title'>Loses</div>
                    <ReactApexChart type='donut' options={avgLoses.options} series={avgLoses.series} className='matches-chart right'/>
                </div>
            </div>
            <div className='statistic-container'>
                <div className='statistics'>
                    <div className='rank-points-container'>
                        <div className='title'>Rank points:</div>
                        <div className='content'>{user.userDetail.rankPoints} lp</div>
                    </div>
                    <div className='last-season-rank-container'>
                    <div className='title'>Last season rank:</div>
                        <div className='content'>{user.userDetail.lastSeasonRank}</div>
                    </div>
                </div>
               
            </div>
        </div>
    )
}