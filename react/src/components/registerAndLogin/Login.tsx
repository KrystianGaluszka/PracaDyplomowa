import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Alert, Form } from 'react-bootstrap'
import { Link, useNavigate } from 'react-router-dom'
import logoImg from '../../logo/logoMini.png'
import "./style.scss"
import '../../utils/buttonStyle.scss'

export const Login = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("")
    const [isChanged, setIsChanged] = useState(false)
    let navigate = useNavigate()
    const cookie = document.cookie.indexOf('jwt') // działa

    useEffect(() => {
        const isLogged = () => {
            if (cookie !== -1) {
                navigate('/home')
                window.location.reload()
            }
        }

        isLogged()
    }, [])

    const onClickLogin = async () => {
        const data = { email, password }
        let response
        let apiError

        await axios.post("https://localhost:44326/api/User/login", data)
            .then(res => {
                response = res.data
                console.log(res.data)
            })
            .catch(error => {
                apiError = error
                console.log('ERROR')
                console.log(error)
            })
            
            console.log(apiError)
        if (apiError !== undefined) {
            navigate('/login')
            setIsChanged(true)
            window.setTimeout(() => {
                setIsChanged(false)
            }, 2000)
        } else if(response === 'success'){
            navigate('/home')
            window.location.reload()
        }

    }

    const handleKeypress = (e: any) => {
        //it triggers by pressing the enter key
      if (e.code === 'Enter' || e.code === "NumpadEnter") {
        onClickLogin();
      }
    };

    return (
        <div className="base-container login-wrapper">
            {isChanged ? <Alert variant='danger' className='alert'  show={isChanged}> 
                <Alert.Heading>Incorrect email or password </Alert.Heading>
            </Alert> : '' }
            <div className="content">
                <div className="image">
                    <img src={ logoImg } />
                </div>
                <Form className="form">
                    <Form.Group className="form-group">
                        <Form.Label htmlFor="email">Email</Form.Label>
                        <Form.Control
                            onKeyPress={e => handleKeypress(e)}
                            required
                            type="text" 
                            name="email" 
                            placeholder="email" 
                            onChange={ (e) => { setEmail(e.target.value) } } 
                        />
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            Cannot be blank!
                        </Form.Control.Feedback>
                    </Form.Group>
                    <Form.Group className="form-group">
                        <Form.Label htmlFor="password">Password</Form.Label>
                        <Form.Control 
                            onKeyPress={handleKeypress}
                            required
                            type="password" 
                            name="password" 
                            placeholder="password" 
                            onChange={ (e) => { setPassword(e.target.value) } } 
                        />
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            Cannot be blank!
                        </Form.Control.Feedback>
                    </Form.Group>
                </Form>
            </div>
            <div className="button-div">
                <button type="button" className="btn-orange" onClick={ onClickLogin }>Login</button>
            </div>
            <div className='footer'>
                <Link to='/register' className='link'>Dont have account? Register here</Link>
            </div>
        </div>
    )
}