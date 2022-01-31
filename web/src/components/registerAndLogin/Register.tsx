import axios from 'axios'
import React, { useState } from 'react'
import { Form, Col, Button } from 'react-bootstrap'
import { Navigate, useNavigate } from 'react-router-dom'
import logoImg from '../../logoMini.png'

export const Register = (props: any) => {
    const [userRegistration, setUserRegistration] = useState({
        name: "",
        email: "",
        password: "",
        clubName: "",
        country: "",
        birthDate: new Date(),
    })
    const [validated, setValidated] = useState(false);

    const navigate = useNavigate()

    const handleInput = (e: any) => {
        const name = e.target.name
        const value = e.target.value

        setUserRegistration({ ...userRegistration, [name]: value })
    }

    const handleSubmit = async (event: any) => {
        const form = event.currentTarget;
        if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
            setValidated(false)
            navigate('/register')
            console.log('NOT VALIDATE')
        }
        else {
            setValidated(true);
            console.log('VALIDATE')

            const email = userRegistration.email
            const name = userRegistration.name
            const password = userRegistration.password
            const clubName = userRegistration.clubName
            const country = userRegistration.country
            const birthDate = userRegistration.birthDate
            const data = { name, email, password, birthDate, clubName, country }

            // let response
            // console.info(JSON.stringify(data))
            // await axios.post('https://localhost:44326/api/User/create', JSON.stringify(data))
            //     .then(res => response = res.data)
            //     .catch(error => console.log(error))
            // // response = await fetch('https://localhost:44326/api/User/create', {
            // //     method: "POST",
            // //     headers: {
            // //         "Content-Type": "application/json"
            // //     },
            // //     body: JSON.stringify(data)
            // // })
            // // const res = await response.json()
            // // console.log(res)
            // console.log(response)

            // if (response === "Account registered successfully") {
            //     navigate('/login')
            //     window.location.reload()
            // }
            // else {
            //     navigate('/register')
            // }
        }
        // setValidated(true)
    };


    const onClickRegister = async () => {
        if (validated) {
            const email = userRegistration.email
            const name = userRegistration.name
            const password = userRegistration.password
            const clubName = userRegistration.clubName
            const country = userRegistration.country
            const birthDate = userRegistration.birthDate
            const data = { name, email, password, birthDate, clubName, country }

            let response
            console.info(JSON.stringify(data))
            await axios.post('https://localhost:44326/api/User/create', JSON.stringify(data))
                .then(res => response = res.data)
                .catch(error => console.log(error))

            console.log(response)

            if (response === "Account registered successfully") { // jeśli id jest w pamięci to przenosi nas na /home
                navigate('/login')
                window.location.reload()
            }
            else {
                navigate('/register')
            }
        }
    }
    console.log(userRegistration)
    return (
        <div className="base-container" >

            <div className="header">Register</div>
            <div className="content">
                <div className="image">
                    <img src={ logoImg } />
                </div>
                <Form noValidate validated={ validated } onSubmit={ onClickRegister } className="form" >
                    <Form.Group as={ Col } md="4" controlId="nameValid" className="form-group">
                        <Form.Label>Name</Form.Label>
                        <Form.Control
                            required
                            type="text"
                            placeholder="Name"
                            name="name"
                            onChange={ e => handleInput(e) }
                        />

                    </Form.Group>

                    <Form.Group as={ Col } md="4" controlId="emailValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Email</Form.Label>
                        <Form.Control
                            required
                            type="text"
                            placeholder="Email"
                            name="email"
                            onChange={ e => handleInput(e) }
                        />

                    </Form.Group>

                    <Form.Group as={ Col } md="6" controlId="passwordValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Password</Form.Label>
                        <Form.Control
                            required
                            type="password"
                            placeholder="Password"
                            name="password"
                            onChange={ e => handleInput(e) }
                        />
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            Have to contain at least
                            one capital letter and digit
                        </Form.Control.Feedback>
                    </Form.Group>

                    <Form.Group as={ Col } md="3" controlId="birthDateValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Birth date</Form.Label>
                        <Form.Control
                            type="date"
                            required
                            name="birthDate"
                            onChange={ e => handleInput(e) }
                        />
                    </Form.Group>

                    <Form.Group as={ Col } md="3" controlId="clubNameValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Club Name</Form.Label>
                        <Form.Control
                            type="text"
                            required
                            placeholder="Club name"
                            name="clubName"
                            onChange={ e => handleInput(e) }
                        />
                    </Form.Group>

                    <Form.Group as={ Col } md="3" controlId="countryValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Country</Form.Label>
                        <Form.Control
                            type="text"
                            required
                            placeholder="Country"
                            name="country"
                            onChange={ e => handleInput(e) }
                        />
                    </Form.Group>

                    <Button className="btn" type="submit">Register</Button>
                </Form>
            </div>
        </div>
    )
}