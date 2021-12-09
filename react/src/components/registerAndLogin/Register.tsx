import React, { useState } from 'react'
import { Navigate } from 'react-router-dom'

export const Register = async (props: any) => {
    const [name, setName] = useState("")
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("")
    const [birthDate, setBirthDate] = useState(Date)
    const [redirect, setRedirect] = useState(false)

    if (redirect) {
        return <Navigate to="/login" />
    }
    else {
        return (
            <h1>INPUTY</h1>
        )
    }
}