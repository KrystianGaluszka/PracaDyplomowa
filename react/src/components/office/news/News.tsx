import axios from 'axios'
import react, { useEffect, useState } from 'react'
import { INotification, IUser } from '../../../shared/interfaces'

export const News = () => {
    const [news, setNews] = useState<INotification[]>()

    useEffect(() => {
        const getNews = async () => {
            let response: IUser
            await axios.get(`https://localhost:44326/api/User/authuser`)
                .then(res => {
                    response = res.data
                    setNews(response.notifications)
                })
        }
    })


    return (
        <div className='news-container'>
            <div className='side-bar'>
            {news?.map((news: INotification) => {
                return(
            <div className='news-content'>
                <div className='news-icon'>
                    ICON
                </div>
                <div className='news-content'>
                    <div className='news-topic'>
                        {news.topic}
                    </div>
                    <div className='news-date'>
                        {news.id}
                    </div>
                </div>
            </div> 
            )})}
            </div>
            <div className='content'>
                <div className='text-content'>

                </div>
            </div>
        </div>
    )
}