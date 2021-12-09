import React, { useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import { Navigate } from 'react-router-dom';
import Moment from 'moment'

const HomePage = (props: any) => {
    const token = localStorage.getItem('user-id')
    const [userData, setUserData] = useState(Object)
    const [userBirthDate, setUserBirthDate] = useState(Date)

    useEffect(() => {
        (
            async () => {
                let result = await fetch(`https://localhost:44326/api/User/${ token }`, {
                    method: 'GET',
                    headers: { "Content-Type": "application/json" },
                    credentials: 'omit',
                });
                const content = await result.json()
                setUserData(content.userMatchesDetails[0])
                setUserBirthDate(content.birthDate)
            }
        )()
    });

    return (
        <>
            <h1>HOME PAGE</h1>
            <h2>id: { token }</h2>
            <h3>details table id: { userData.id }</h3>
            <h3>Uro: { Moment(userBirthDate).format('d MMMM YYYY') }</h3>
        </>
    )
}

export default HomePage;