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

                <NavLink className="d-inline p-2 bg-dark text-white" to="UserInfo">
                    UserInfo
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="UserRegistry">
                    UserRegistry
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="ExplosiveSearchPage">
                    ExplosiveSearchPage
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="registration">
                    UserRegistration
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="login">
                    LoginForm
                </NavLink>

                <NavLink className="d-inline p-2 bg-dark text-white" to="explosiveRegister">
                    ExplosiveRegistryPage
                </NavLink>
            </Nav>
        </Navbar.Collapse>
    </Navbar>
);

export default Navigation;
