import React, { useState, useEffect, ReactPropTypes } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { Navigate } from 'react-router-dom'
import "./style.scss"

export const Login = (props: any) => {
    useEffect(() => {
        (
            () => {
                if (localStorage.getItem('user-id') !== "") {
                    setRedirect(true)
                }
                else {
                    setRedirect(false)
                }
            })()
    })

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("")
    const [redirect, setRedirect] = useState(Boolean)

    let navigate = useNavigate()

    const OnClickLogin = async () => {
        let data = { email, password }
        console.info(JSON.stringify(data))

        let result = await fetch("https://localhost:44326/api/User/login", {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            credentials: 'omit',
            body: JSON.stringify(data)
        });
        result = await result.json(); // bez tego ani rusz

        const token = JSON.parse(JSON.stringify(result))
        localStorage.setItem("user-id", token)

        if (localStorage.getItem('user-id') !== "") { // jeśli id jest w pamięci to przenosi nas na /home
            navigate('/home')
            window.location.reload()
        }
        else {
            navigate('/login')
        }

    }
    if (redirect) {
        return <Navigate to="/home" />
    }
    else {
        return (
            <div className="login-container">
                <h1>Login in</h1>
                <input type="text" onChange={ (e) => { setEmail(e.target.value) } } placeholder="Email" className="login-container__email" />
                <input type="password" onChange={ (e) => { setPassword(e.target.value) } } placeholder="Password" className="login-container__password" />
                <button onClick={ OnClickLogin } className="login-container__submit">Log in</button>
            </div>
        )
    }
}