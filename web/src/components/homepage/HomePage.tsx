import React, { useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import { Navigate } from 'react-router-dom';
import Moment from 'moment'
import './style.scss'
import axios from 'axios';

const HomePage = (props: any) => {
    const token = localStorage.getItem('user-id')
    const [userData, setUserData] = useState(Object)
    const [userDetail, setUserDetail] = useState(Object)
    const [userBirthDate, setUserBirthDate] = useState(Date)
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {

        const fetchData = async () => {
            await axios.get(`https://localhost:44326/api/User/${ token }`)
                .then(response => {
                    setUserData(response.data)
                    setUserDetail(response.data.userDetail)
                    setUserBirthDate(response.data.birthDate)
                    setIsLoading(false)
                })
        }

        fetchData()
    }, []);

    console.log(userData)

    if (isLoading) {
        return (
            <div className='homeContainer'>
                <h1>LOADING...</h1>
            </div>
        )
    }
    else {
        return (
            <div className='homeContainer'>
                <h1>HOME PAGE</h1>
                <h5>ID:  { token }</h5>
                <h2>Name : { userData.name }</h2>
                <h2>Matches played: { userDetail.matchesPlayed }</h2>
                <h3>Uro: { Moment(userBirthDate).format('d MMMM YYYY') }</h3>
            </div>
        )
    }
}

export default HomePage;