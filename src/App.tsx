import React from 'react';
import logo from './logo.svg';
import './App.css';

import Home from './pages/Home';
import Navigation from './components/Navigation';
import UserInfo from './pages/UserInfo';
import UserRegistry from './pages/UserRegistry';
import ExplosiveSearchPage from './pages/ExplosiveSearchPage';

import { BrowserRouter, Route, Switch } from 'react-router-dom';
import UserRegistration from './pages/UserRegistration';

function App() {
    const isAuthenticated = false;

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
                            <Route path="/registration" component={UserRegistration} exact />
                        </>
                    )}
                </Switch>
            </div>
        </BrowserRouter>
    );
}

export default App;
