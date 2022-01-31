import React, { useEffect } from 'react'
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css'
import { Container, Nav, Navbar } from 'react-bootstrap';
import "./style.scss"

export const Layout = () => {
    const token = localStorage.getItem('user-id')

    const OnClickLogout = () => {
        localStorage.setItem('user-id', '')
    }

    const checkIfLogged = () => {
        if (token !== "") {
            return (<Nav.Link href="/" onClick={ OnClickLogout } >Logout</Nav.Link>)
        }
        else {
            return (<Nav.Link href="login">Login</Nav.Link>)
        }
    }

    return (
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
            <Container>
                <Navbar.Brand href="/">BSM</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link href="home">Home</Nav.Link>
                        <Nav.Link href="register">Register</Nav.Link>

                    </Nav>
                    <Nav>
                        { checkIfLogged() }
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}