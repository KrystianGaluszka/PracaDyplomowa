import axios from 'axios';
import React, { useState, useEffect, ReactPropTypes } from 'react'
import { Link, useNavigate, Navigate } from 'react-router-dom';
import logoImg from '../../logoMini.png'
import "./style.scss"

export const Login = (props: any) => {
    useEffect(() => {
        (
            () => {
                if (localStorage.getItem('user-id') !== "") {
                    setRedirect(false)
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

    const onClickLogin = async () => {
        let data = { email, password }
        console.info(JSON.stringify(data))
        let response
        await axios.post("https://localhost:44326/api/User/login", data)
            .then(res => {
                response = res.data
                localStorage.setItem("user-id", response.id)
            })
            .catch(error => console.log(error))
        console.log(response)

        const getToken = localStorage.getItem('user-id')

        if (getToken === "") { // jeśli id jest w pamięci to przenosi nas na /home
            navigate('/login')
        }
        else {
            // navigate('/home')
            // window.location.reload()
        }
    }

    if (redirect) {
        return <Navigate to="/home" />
    }
    else {
        return (
            <div className="base-container">
                <div className="header">Login</div>
                <div className="content">
                    <div className="image">
                        <img src={ logoImg } />
                    </div>
                    <div className="form">
                        <div className="form-group">
                            <label htmlFor="email">Email</label>
                            <input type="text" name="email" placeholder="email" onChange={ (e) => { setEmail(e.target.value) } } />
                        </div>
                        <div className="form-group">
                            <label htmlFor="password">Password</label>
                            <input type="password" name="password" placeholder="password" onChange={ (e) => { setPassword(e.target.value) } } />
                        </div>
                    </div>
                </div>
                <div className="footer">
                    <button type="button" className="btn" onClick={ onClickLogin }>Login</button>
                </div>
            </div>
        )
    }
}