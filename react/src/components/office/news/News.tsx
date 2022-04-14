import axios from 'axios'
import react, { useEffect, useState } from 'react'
import { BsTrash } from 'react-icons/bs'
import { INotification, IUser } from '../../../shared/interfaces'
import Moment from 'moment'
import '../../../utils/buttonStyle.scss'
import './style.scss'
import { Alert, Button } from 'react-bootstrap'

export const News = ({user}: {user: IUser}) => {
    const [news, setNews] = useState<INotification[]>([])
    const [newsContent, setNewsContent] = useState<string>('')
    const [newsTopic, setNewsTopic] = useState('')
    const [newsId, setNewsId] = useState<number>(0)
    const [userId, setUserId] = useState('')
    const [divDisplay, setDivDisplay] = useState('none')
    const [isChanged, setIsChanged] = useState(false)
    const [isNoNews, setIsNoNews] = useState(false)

    useEffect(() => {
        const getNews = async () => {
            setNews(user.notifications.sort(dynamicSort('createDate')))
            setUserId(user.id)
            
            if (user.notifications.length <= 0) {
                setIsNoNews(true)
            }
        }

        getNews()
    }, [])

    const readOnClick = async (newsId: number) => {
        await axios.put(`https://localhost:44326/api/Notification/read?notificationId=${newsId}`)
                .catch(error => console.log(error))
    }


    const displayOnClick = (newsId: number) => {
        const clickedNews = news.find(x=> x.id == newsId)
        const oldNews = newsContent

        if(clickedNews !== undefined) {
            if(oldNews === clickedNews.content) {
                setDivDisplay('none')
                setNewsContent('')
            } else {
                setNewsContent(clickedNews.content)
                setNewsTopic(clickedNews.topic)
                setDivDisplay('block')
                readOnClick(newsId)
                setNewsId(newsId)
            }
             
        }
    }

    const deleteOnClick = async () => {
        let response: string
        await axios.delete(`https://localhost:44326/api/Notification/delete?notificationId=${newsId}`)
            .then(res => {
                response = res.data
                if(response === 'success') {
                    setNews(news.filter(x=> x.id !== newsId))
                    setIsChanged(true)
                    setDivDisplay('none')
                    setNewsContent('')
                }
            })
            .catch(error => console.log(error))
    }
    const deleteAllOnClick = async () => {
        let response: string
        await axios.delete(`https://localhost:44326/api/Notification/deleteAll?userId=${userId}`)
            .then(res => {
                response = res.data
                if(response === 'success') {
                    setNews([])
                    setIsChanged(true)
                    setDivDisplay('none')
                    setIsNoNews(true)
                }
            })
            .catch(error => console.log(error))
    }

    const dynamicSort = (property: string) => {
        let sortOrder = -1;
        if(property[0] === "-") {
            sortOrder = 1;
            property = property.substr(1);
        }
        return function (a:any ,b: any) {

            var result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
            return result * sortOrder;
        }
    }

    return (
        <div className='news-container'>
            <div className='side-bar'>
            {news.length > 0 ? news.map((notification: INotification) => {
                return(
                <button className={notification.isRead ? 'news read' : 'news'} key={notification.id} onClick={() => displayOnClick(notification.id)}>
                    <div className='news-content'>
                        <div className='news-icon'>
                            <img src={notification.iconPath} />
                        </div>
                        <div className='news-topic'>
                            {notification.topic.length > 10 ? notification.topic.substring(0,10) + '...' : notification.topic}
                        </div>
                    </div>
                    <div className='news-date'>
                        {Moment(notification.createDate).format('DD.MM.YYYY') }
                    </div>
                    {news[news.length-1].id !== notification.id ? <hr/> : ''}
                </button> 
            )}) : <div className='no-news'>No notifications</div>}
            <div className='side-footer'>
                {!isNoNews ? <button className='btn-orange' onClick={deleteAllOnClick}><BsTrash /> All</button> : ''}
            </div>
            </div>
            <div  className='content'>
                {isChanged ? <Alert className='alert ' variant="success">
                    Deleted successfully
                    <Button className='alert-button' onClick={() => setIsChanged(false)} variant="outline-success">
                        Close
                    </Button>
                </Alert> : ''}
                <div style={{display: divDisplay}}>
                    <div className='topic'>
                        {newsTopic}
                    </div>
                    <hr />
                    <div  className='text-content'>
                        {newsContent}
                    </div>
                    <div className='footer'>
                        <button className='btn-orange' onClick={deleteOnClick}><BsTrash /></button>
                    </div>
                </div>
            </div>
        </div>
    )
}