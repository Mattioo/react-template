import React, { useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAdjust } from '@fortawesome/free-solid-svg-icons'

const Toolbar = ({ fontSize, setFontSize, contrast, setContrast, languages, lang, setLang }) => {

    const [languageListVisible, setLanguageListVisible] = useState(false);

    return (
        <React.Fragment>
            <div className={`app-toolbar${(contrast ? ' contrast' : '')}`} >
                <div className="app-toolbar--left">
                    <div className="app-toolbar--item" onClick={() => {
                        const size = Math.min(fontSize + 10, 130)          
                        if (window.sessionStorage) {
                            window.sessionStorage.setItem('fontSize', size)
                        }
                        setFontSize(size)
                    }}>
                        <span>A+</span>
                    </div>
                    <div className="app-toolbar--item" onClick={() => {
                        const size = Math.max(fontSize - 10, 100)
                        if (window.sessionStorage) {
                            window.sessionStorage.setItem('fontSize', size)
                        }
                        setFontSize(size)
                    }}>
                        <span>A-</span>
                    </div>
                    <div className="app-toolbar--item" onClick={() => {
                        if (window.sessionStorage) {
                            window.sessionStorage.setItem('contrast', !contrast)
                        }
                        setContrast(!contrast)
                    }}>
                        <FontAwesomeIcon icon={faAdjust} />
                        <span className="app-toolbar--item--adjust">Wersja kontrastowa</span>
                    </div>
                </div>
                <div className="app-toolbar--right">
                    <div className="app-toolbar--lang--main" onClick={() => setLanguageListVisible(true)}>
                        <div className="app-toolbar--lang">
                            <i className={`flag:${lang}`}></i>
                        </div>
                    </div>
                    {
                        languageListVisible ?
                            <div className="app-toolbar--lang--list" onMouseLeave={() => setLanguageListVisible(false)}>
                                {
                                    languages.filter(x => x.short !== lang).map((language) =>
                                        <div className="app-toolbar--lang" key={language.short} title={language.name} onClick={() => setLanguageListVisible(false)}>
                                            <i className={`flag:${language.short}`} onClick={() => {
                                                if (window.sessionStorage) {
                                                    window.sessionStorage.setItem('lang', language.short)
                                                }
                                                setLang(language.short)
                                            }}></i>
                                        </div>
                                    )
                                }
                            </div> :  null
                    }
                </div>
            </div>
        </React.Fragment>
    )
}

export default Toolbar