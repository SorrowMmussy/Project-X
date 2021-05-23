import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

import Home from './pages/Home';
import Navigation from './components/Navigation';
import UserInfo from './pages/UserInfo';

import { BrowserRouter, Route, Switch } from 'react-router-dom';
import UserRegistration from './pages/UserRegistration';
import LoginForm, { isLoggedIn } from './pages/LoginForm';
import ExplosiveRegisterPage from './pages/ExplosiveRegisterPage';
import NewUserRegistry from './pages/NewUserRegistry';
import Logout from './pages/Logout';
import ExplosiveSearchPage from './pages/ExplosiveSearchPage';
import ExplosiveEditPage from './pages/ExplosiveEditPage';

function App() {
    const isAuthenticated = isLoggedIn();

    return (
        <BrowserRouter>
            <div className="container">
                <h3 className="m-3 d-flex justify-content-center">Explosives ARE OP!!!</h3>

                <Navigation />

                <Switch>
                    {isAuthenticated ? (
                        <>
                            <Route path="/userInfo" component={UserInfo} exact />
                            <Route path="/explosiveRegister" component={ExplosiveRegisterPage} exact />
                            <Route path="/newUserRegistry" component={NewUserRegistry} exact />
                            <Route path="/logout" component={Logout} exact />
                            <Route path="/explosiveSearchPage" component={ExplosiveSearchPage} exact />
                            <Route path="/explosiveEditPage/:id" component={ExplosiveEditPage} />
                            {/*<Route path="/addNewUser" component={AddNewUserPage} exact />*/}
                        </>
                    ) : (
                        <>
                            <Route path="/" component={Home} exact />
                            <Route path="/login" component={LoginForm} exact />
                            <Route path="/registration/:token" component={UserRegistration} exact />
                        </>
                    )}
                </Switch>
            </div>
        </BrowserRouter>
    );
}

export default App;
