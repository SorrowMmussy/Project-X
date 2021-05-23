import React from 'react';
import { NavLink } from 'react-router-dom';
import { Navbar, Nav } from 'react-bootstrap';

console.log(Navbar, Navbar.Toggle, Navbar.Collapse, Nav, NavLink);
const Navigation = () => (
    <Navbar bg="dark" expand="lg">
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
            <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                    Home
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="/UserInfo">
                    User Info
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="/newUserRegistry">
                    New User Registration
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="/explosiveSearchPage">
                    Explosives Search Page
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="/registration">
                    UserRegistration
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
                    Login page
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="/explosiveRegister">
                    Explosive registration page
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="/explosiveEditPage">
                    Explosive edit page
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="/Logout">
                    Logout
                </NavLink>
            </Nav>
        </Navbar.Collapse>
    </Navbar>
);

export default Navigation;
