import React from 'react';
import { useState, useEffect } from 'react';
import { Link } from "react-router-dom";

import styles from './navbar-styles.module.scss';

import logo from '../../static/images/logo.png';
import contrastLogo from '../../static/images/contrast-logo.png';

const NavbarTemplate = (props) => {

    const [navbarList, setNavbarList] = useState([]);
    const { pathname } = props.location;

    useEffect(() => {
        if (props.pathInState !== pathname) {
            props.changePathInState(pathname);
        }

        async function fetchData() {
            const response = await fetch(`/api/app/navbar?lang=${props.language}`);
            const data = await response.json();
            setNavbarList(data);
        }
        fetchData();
    });

    function createNavbarElement(el) {
        return (
            <li key={el.name} title={el.title} className={
                !el.active ?
                    styles.navbarDisabledElement :
                    (
                        el.url === pathname ?
                            styles.navbarChoosedElement :
                            undefined
                    )
            }
                onClick={
                    el.active ?
                        () => { props.changePathInState(el.url) } :
                        undefined
                }
                onKeyDown={
                    (e) => { !el.active && e.key === 'Enter' && e.preventDefault(); }
                }>
                <Link to={`${el.url}`} className={
                    !el.active ?
                        styles.navbarDisabledLink :
                        undefined
                }>
                    {el.content}
                </Link>
            </li>
        );
    }

    const navbarClass = `${styles.navbar}${(props.contrast ? ' ' + styles.contrast : '')}`;
    return (
        <div className={navbarClass}>
            <nav className={styles.navbarContent}>
                <div className={styles.navbarLogo}>
                    <Link to='/'>
                        <img src={props.contrast ? contrastLogo : logo} alt='Logo' className={styles.navbarLogoImage} />
                    </Link>
                </div>           
                <ul>
                    {navbarList.map(el => createNavbarElement(el))}
                </ul>
            </nav>
        </div>
    );
}

export default NavbarTemplate;
