import React from 'react';
import './App.css';

import Home from './pages/Home';
import Navigation from './components/Navigation';
import UserInfo from './pages/UserInfo';
import UserRegistry from './pages/UserRegistry';

import { BrowserRouter, Route, Switch } from 'react-router-dom';
import UserRegistration from './pages/UserRegistration';
import LoginForm, { isLoggedIn } from './pages/LoginForm';

function App() {
    const isAuthenticated = isLoggedIn();

    return (
        <BrowserRouter>
            <div className="container">
                <h3 className="m-3 d-flex justify-content-center">React Test</h3>

                <Navigation />

                <Switch>
                    {isAuthenticated ? (
                        <>
                            <Route path="/userInfo" component={UserInfo} exact />
                            <Route path="/userRegistry" component={UserRegistry} exact />
                            {/*<Route path="/addNewUser" component={AddNewUserPage} exact />*/}
                        </>
                    ) : (
                        <>
                            <Route path="/" component={Home} exact />
                            <Route path="/registration/:token" component={UserRegistration} exact />
                            <Route path="/login" component={LoginForm} exact />
                        </>
                    )}
                </Switch>
            </div>
        </BrowserRouter>
    );
}

export default App;
