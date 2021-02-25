import HeaderActions from './Actions/header';
import NavbarActions from './Actions/navbar';

export function reducer(state, action) {

    const storage = window.sessionStorage;

    if (state === undefined) {
        return {
            header: {
                language: {
                    set: (storage && storage.getItem('language')) || 'PL',
                    availables: ['PL', 'US', 'DE']
                },
                contrast: (storage && storage.getItem('contrast') === "true") || false,
                fontSize: (storage && storage.getItem('fontSize')) || 100
            },
            navbar: {
                path: '/'
            }
        }
    }
    switch (action.type) {
        case HeaderActions.CHANGE_LANGUAGE:
            if (storage) {
                storage.setItem('language', action.language);
            }
            return {
                ...state,
                header: {
                    ...state.header,
                    language: {
                        ...state.header.language,
                        set: action.language
                    }
                }
            };
        case HeaderActions.CHANGE_CONTRAST:
            if (storage) {
                storage.setItem('contrast', action.contrast);
            }
            return {
                ...state,
                header: {
                    ...state.header,
                    contrast: action.contrast
                }
            };
        case HeaderActions.CHANGE_FONT_SIZE:
            if (storage) {
                storage.setItem('fontSize', action.fontSize);
            }
            return {
                ...state,
                header: {
                    ...state.header,
                    fontSize: action.fontSize
                }
            };
        case NavbarActions.CHANGE_PATH_IN_STATE:
            return {
                ...state,
                navbar: {
                    path: action.path
                }
            }
        default:
            return state;
    }
}