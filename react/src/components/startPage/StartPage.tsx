import react, { useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import './style.scss'

export const StartPage = () => {
    var path = 'https://localhost:44326/images/'
    let navigate = useNavigate()
    const cookie = document.cookie.indexOf('jwt') // działa

    useEffect(() => {
        const isLogged = () => {
            if (cookie !== -1) {
                navigate('/home')
                window.location.reload()
            }
        }

        isLogged()
    }, [])

    return(
        <div className='start-page-container'>
            <div className='card'>
                <div className='logo'>
                    <img src='https://localhost:44326/images/logo/mainLogo.png' />
                </div>
                <div className='welcome-sub-card'>
                    <div className='under-title'>The best free 2 play basketball manager game so far!</div>
                    <div className='text'>
                        Turn into the best manager in the world, managing your team and rise to the heights.
                        Get the best players, set tour team and win all the matches.
                    </div>

                </div>
                <div className='register-sub-card'>
                    <div className='text'>JOIN NOW!</div>
                    <div className='register-button'><a href='/register' className='btn-orange'>Register</a></div>
                </div>
                <div className='login-sub-card'>
                    <div className='text'>Already have account?</div>
                    <div className='login-container'><a href='/login'>Log in</a></div>
                </div>
            </div>
        </div> 
    )
}