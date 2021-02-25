import React from 'react';
import { useState, useEffect } from 'react';
import { Link } from "react-router-dom";

import './navbar.scss';
import logo from './logo.png';

const NavbarTemplate = (props) => {

    const [navbarList, setNavbarList] = useState([]);
    const { pathname } = props.location;

    useEffect(() => {
        async function fetchData() {
            const response = await fetch(`/api/app/navbar?lang=${props.language}`);
            const data = await response.json();
            setNavbarList(data);
        }

        if (props.pathInState !== pathname) {
            props.changePathInState(pathname);
        }
        fetchData();   
    });

    function createNavbarElement(el) {
        const disabledClass = `${(el.active ? '' : 'disabled')}` || undefined;
        const choosedClass = `${(el.url !== pathname ? '' : 'choosed')}` || undefined;

        return (
            <li key={el.name} title={el.title} className={disabledClass || choosedClass} onClick={el.active ? () => { props.changePathInState(el.url) } : undefined} onKeyDown={
                (e) => { !el.active && e.key === 'Enter' && e.preventDefault(); }
            }>
                <Link to={`${el.url}`} className={disabledClass}>{el.content}</Link>
            </li>
        );
    }

    return (
        <div className='navbar'>
            <Link to='/'>
                <img src={logo} alt='Logo' className='logo' />
            </Link>           
            <nav>              
                <ul>
                    {navbarList.map(el => createNavbarElement(el))}
                </ul>
            </nav>
        </div>
    );
}

export default NavbarTemplate;
