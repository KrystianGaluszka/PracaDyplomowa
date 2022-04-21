import axios from 'axios'
import react, { useEffect, useState } from 'react'
import Moment from 'moment'
import { IUser } from '../../../shared/interfaces'
import '../../../utils/buttonStyle.scss'
import './style.scss'
import { Alert, Form } from 'react-bootstrap'
import countryList from 'react-select-country-list'


export const Profile = ( {userProp}: {userProp: IUser} ) => {
    const [user, setUser] = useState<IUser>()
    const [userPassword, setUserPassword] = useState('')
    const [picPath, setPicPath] = useState('')
    const [isDisable, setIsDisable] = useState(true)
    const [isDisable1, setIsDisable1] = useState(true)
    const [isDisable2, setIsDisable2] = useState(true)
    const [isDisable3, setIsDisable3] = useState(true)
    const [selectValue, setSelectValue] = useState('')
    const [isChanged, setIsChanged] = useState(false)
    const [imageView, setImageView] = useState('')
    const [image, setImage] = useState<string | Blob>('')
    const [imageName, setImageName] = useState('')
    const [editIcon, setEditIcon] = useState('')
    const [userEdit, setUserEdit] = useState({
        password: "",
        clubName: "",
        country: "",
    })
    let options = new Array()
    
    countryList().getData().map((data: any) => {
        options.push(data)
    })

    useEffect(() => {
        const getUser = async () => {
            setUser(userProp)
            setPicPath(userProp.profilePicturePath)
            setEditIcon('https://localhost:44326/images/edit.png')
            setUserPassword('●'.repeat(userProp.password.length))
        }

        getUser()
    }, [])

    const handleInput = (e: any) => {
        const name = e.target.name
        const value = e.target.value
        setUserEdit({ ...userEdit, [name]: value })
    }

    const selectChangeHandler = (event: any) => {
        const value = event.currentTarget.value 
        setSelectValue(value)
        setUserEdit({...userEdit, "country": value})
    }

    const handleOnEdit = (e: any) => {
        e.preventDefault()
        setIsDisable(!isDisable)
    }

    const handleOnEdit1 = (e: any) => {
        e.preventDefault()
        setIsDisable1(!isDisable1)
    }

    const handleOnEdit2 = (e: any) => {
        e.preventDefault()
        setIsDisable2(!isDisable2)
    }

    const OnImageChange = (e: any) => {
        if (e.target.files && e.target.files[0]) {
            let img = e.target.files[0];
            setImageView(URL.createObjectURL(img))
            setImage(img)
            setImageName(img.name)
            setIsDisable3(false)

            const formData = new FormData()
            formData.append( 
                "myFile", 
                img,
            ); 
        }
    }

    const handleEditSubmit = async () => {
        const id = user?.id

        if (image !== '') {         
            const imageData = new FormData()
            imageData.append('image', image) 

            await axios.post('https://localhost:44326/api/User/uploadImage', imageData)
                    .catch(error => console.log(error))
        }

        const clubName = userEdit.clubName
        const country = userEdit.country
        const password = userEdit.password
        const profilePicturePath = imageName
    
        let response: any

        const data = { id, clubName, country, password, profilePicturePath }
        await axios.put<IUser>(`https://localhost:44326/api/User/edit`, data)
                .then(res => response = res.data)
                .catch(error => console.log(error))

        if (response === "ok") {
            if (clubName === "" && country === "" && password === "" && profilePicturePath === ""){
                setIsDisable(true)
                setIsDisable1(true)
                setIsDisable2(true)
            } else {
                setIsChanged(true)
                window.setTimeout(() => {
                    window.location.reload()
                    setIsChanged(false)
                }, 600)
            }
        }
    }

    return (
        <div className='profile-container'>
            {isChanged ? <Alert variant='success' className='success-alert'  show={isChanged}> 
                <Alert.Heading>Changed successfully </Alert.Heading>
            </Alert> : '' }
            <div className='profile-container--user-info'>
                <div className='name-and-picture'>
                    <div className='picture'>
                            <label className="upload-image">
                                <img alt="profilePicture" src={ imageView=== '' ? picPath : imageView } />
                                <input
                                    style={{ display: 'none' }}
                                    type="file"
                                    accept='image/*'
                                    name='myImage'
                                    onChange={e => OnImageChange(e)}
                                />
                                <div className='middle' >
                                    <img alt='editIcon' src={ editIcon }/>
                                </div>
                            </label>
                    </div>
                    <div className='name'>{user?.name}</div>
                </div>
                <div className='user-info-content'>
                    <div className='header'>INFORMATION</div>
                    <hr/>
                    <Form className='info-table'>
                        <Form.Group className='info-table-cell'>
                            <div className='title'>Email</div>
                            <div className='content'>{ user?.email }</div>
                        </Form.Group>
                        <hr />
                        <Form.Group className='info-table-cell'>
                            <div className='title'>
                                <div>Club name </div>
                                <button className='edit' onClick={e=> {handleOnEdit(e)}}>
                                    <img alt='editIcon' src={ editIcon }/>
                                </button>
                            </div>
                            {isDisable ? <div className='content'>{ user?.clubName }</div> : 
                            <Form.Control className='edit-input'
                                type="text"
                                placeholder="new club name"
                                name="clubName"
                                maxLength={8}
                                onChange={ e => handleInput(e) } />}
                            
                        </Form.Group>
                        <hr />
                        <Form.Group className='info-table-cell'>
                            <div className='title'>Birth date</div>
                            <div className='content'>{ Moment(user?.birthDate).format('DD.MM.YYYY') }</div>
                        </Form.Group>
                        <hr />
                        <Form.Group className='info-table-cell'>
                            <div className='title'>
                                Country
                                <button className='edit' onClick={e=> {handleOnEdit1(e)}}>
                                    <img alt='editIcon' src={ editIcon }/>
                                </button>
                            </div>
                            {isDisable1 ? <div className='content'>{ user?.country }</div> :
                                <Form.Select
                                className='edit-select'
                                name="country"
                                onChange={ e => selectChangeHandler(e) }
                                value={selectValue}
                            >
                                <option value="" disabled hidden>{user?.country}</option>
                                {options.map(option => (
                                    <option key={option.value} value={option.label}>
                                        {option.label}
                                    </option>
                                ))}
                            </Form.Select>
                                }
                            
                        </Form.Group>
                        <hr />
                        <Form.Group className='info-table-cell'>
                            <div className='title'>
                                <div>Password </div>
                                <button className='edit' onClick={e=> {handleOnEdit2(e)}}>
                                    <img alt='editIcon' src={ editIcon }/>
                                </button>
                            </div>
                            {isDisable2 ? <div className='content'>{ userPassword }</div> : 
                            <Form.Control className='edit-input'
                                type="password"
                                placeholder="new password"
                                name="password"
                                onChange={ e => handleInput(e) } />}
                            
                        </Form.Group>
                        {(isDisable && isDisable1 && isDisable2 && isDisable3) ? '' : <div className='footer'>
                            <button type='button' className='btn-blue' onClick={handleEditSubmit}>Save</button>
                        </div>}
                    </Form>
                </div>
            </div>
        </div>
    )
}