import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Form, Col } from 'react-bootstrap'
import { Link, useNavigate } from 'react-router-dom'
import countryList from 'react-select-country-list'
import logoImg from '../../logo/logoMini.png'
import { IUser } from '../../shared/interfaces'
import '../../utils/buttonStyle.scss'

export const Register = () => {
    const [userRegistration, setUserRegistration] = useState({
        name: "",
        email: "",
        password: "",
        clubName: "",
        country: "",
        birthDate: null,
    })

    const email = userRegistration.email
    const name = userRegistration.name
    const password = userRegistration.password
    const clubName = userRegistration.clubName
    const country = userRegistration.country
    const birthDate = userRegistration.birthDate

    const [nameError, setNameError] = useState("")
    const [emailError, setEmailError] = useState("")
    const [passwordError, setPasswordError] = useState("")
    const [birthDateError, setBirthDateError] = useState("")
    const [clubNameError, setClubNameError] = useState("")
    const [countryError, setCountryError] = useState("")
    const [emails, setEmails] = useState<string[]>([])
    const [selectValue, setSelectValue] = useState('')
    const navigate = useNavigate()
    const cookie = document.cookie.indexOf('jwt') // działa

    let options = new Array()
    let isValidate = true
    
    useEffect(() => {
        const getEmail = async () => {
            if (cookie !== -1) {
                navigate('/home')
                window.location.reload()
            } else {
                await axios.get<IUser[]>('https://localhost:44326/api/User')
                .then(res => {
                    res.data.map((user: IUser) => {
                        setEmails(email => [...email, user.email])
                    })
                })
            }
        }
        
        getEmail()
    }, [])

    countryList().getData().map((data: any) => {
        options.push(data)
    })

    const selectChangeHandler = (event: any) => {
        const value = event.currentTarget.value 
        setSelectValue(value)
    }

    const handleInput = (e: any) => {
        const name = e.target.name
        const value = e.target.value

        setUserRegistration({ ...userRegistration, [name]: value })
    }

    const handleValidation = async () => {
        const minCharacters = 6
        const maxCharacters = 16
        const passwordRegex = /^(?=.*[0-9])[a-zA-Z0-9]{6,16}$/
        const emailRegex = /^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/
        const todayDate = new Date().getTime()

        let selectedDate
        if (name === "") {
            setNameError('Cannot be blank!')
            isValidate = false
        } else {
            setNameError("")
        }

        if (email === "") {
            setEmailError('Cannot be blank!')

            isValidate = false
        } else if (!emailRegex.test(email)) { 
            setEmailError('Incorrect email form')

            isValidate = false
        } else if(emails.includes(email)) {
            setEmailError('Email already exists')

            isValidate = false
        } else {
            setEmailError('')
        }

        if (password === "") {
            setPasswordError('Cannot be blank!')

            isValidate = false
        } else if (password.length < minCharacters || password.length > maxCharacters) {
            setPasswordError('Must contain at least 6 characters and max 16 characters')

            isValidate = false
        } else if (!passwordRegex.test(password)) {
            setPasswordError('Must contain at least one capital letter and digit')

            isValidate = false
        } else {
            setPasswordError('')
        }

        if (birthDate === null) {
            setBirthDateError('Cannot be blank!')

            isValidate = false
        } else {
            selectedDate = Date.parse(birthDate)

            if (selectedDate > todayDate) {
                setBirthDateError('Cannot be above the current period')

                isValidate = false
            } else {
                setBirthDateError('')
            }
        } 

        if (clubName === "") {
            setClubNameError('Cannot be blank!')

            isValidate = false
        } else {
            setClubNameError('')
        }

        if (country === "") {
            setCountryError('Cannot be blank!')

            isValidate = false
        } else {
            setCountryError('')
        }
    }

    const onSubmitHandler = async () => {
        handleValidation()

        if(isValidate) {
            const data = { name, email, password, birthDate, clubName, country }

            let response
            console.info(JSON.stringify(data))
            await axios.post('https://localhost:44326/api/User/create', data)
                .then(res => response = res.data)
                .catch(error => console.log(error))

            if (response === "account_registered_successfully") {
                navigate('/login')
                window.location.reload()
            }
        }
    }

    const handleKeypress = (e: any) => {
        //it triggers by pressing the enter key
      if (e.code === 'Enter' || e.code === "NumpadEnter") {
        onSubmitHandler();
      }
    };

    return (
        <div className="base-container" >
            <div className="content">
                <div className="image">
                    <img src={ logoImg } />
                </div>
                <Form className="form" >
                    <Form.Group as={ Col } md="4" controlId="nameValid" className="form-group">
                        <Form.Label>Name</Form.Label>
                        <Form.Control
                            onKeyPress={handleKeypress}
                            isInvalid={ !!nameError }
                            type="text"
                            placeholder="Name"
                            name="name"
                            onChange={ e => handleInput(e) }
                        />
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            { nameError }
                        </Form.Control.Feedback>
                    </Form.Group>

                    <Form.Group as={ Col } md="4" controlId="emailValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Email</Form.Label>
                        <Form.Control
                            onKeyPress={handleKeypress}
                            isInvalid={ !!emailError }
                            type="text"
                            placeholder="Email"
                            name="email"
                            onChange={ e => handleInput(e) }
                        />
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            { emailError }
                        </Form.Control.Feedback>
                    </Form.Group>

                    <Form.Group as={ Col } md="6" controlId="passwordValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Password</Form.Label>
                        <Form.Control
                            onKeyPress={handleKeypress}
                            isInvalid={!!passwordError}
                            type="password"
                            placeholder="Password"
                            name="password"
                            onChange={ e => handleInput(e) }
                        />
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            { passwordError }
                        </Form.Control.Feedback>
                    </Form.Group>

                    <Form.Group as={ Col } md="3" controlId="birthDateValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Birth date</Form.Label>
                        <Form.Control
                            onKeyPress={handleKeypress}
                            isInvalid={!!birthDateError}
                            placeholder='Select date'
                            type="date"
                            name="birthDate"
                            onChange={ e => handleInput(e) }
                        />
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            { birthDateError }
                        </Form.Control.Feedback>
                    </Form.Group>

                    <Form.Group as={ Col } md="3" controlId="clubNameValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Club Name</Form.Label>
                        <Form.Control
                            onKeyPress={handleKeypress}
                            isInvalid={!!clubNameError}
                            type="text"
                            placeholder="Club name"
                            maxLength={8}
                            name="clubName"
                            onChange={ e => handleInput(e) }
                        />
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            { clubNameError }
                        </Form.Control.Feedback>
                    </Form.Group>

                    <Form.Group as={ Col } md="3" controlId="countryValid" className="form-group" onChange={ handleInput }>
                        <Form.Label>Country</Form.Label>
                        <Form.Select
                            onKeyPress={handleKeypress}
                            isInvalid={!!countryError}
                            placeholder="Select country"
                            name="country"
                            onChange={ e => selectChangeHandler(e) }
                            value={selectValue}
                        >
                            <option value="" disabled hidden>Select country</option>
                            {options.map(option => (
                                <option key={option.value} value={option.label}>
                                    {option.label}
                                </option>
                            ))}
                        </Form.Select>
                        <Form.Control.Feedback type="invalid" className='invalid-msg'>
                            { countryError }
                        </Form.Control.Feedback>
                    </Form.Group>
                    <button className="btn-orange" type="button" onClick={ onSubmitHandler } >Register</button>
                </Form>
            </div>
            <div className='footer'>
                <Link to='/login' className='link'>Already have account? Log in</Link>
            </div>
        </div>
    )
}