import axios from 'axios';

//URL PHP файлов 
const USER_API_URL = 'http://localhost/PHP'

class UserDataService {
    //Обновление контактов из базы данных
    retrieveAllUsers() {

        return axios.get(`${USER_API_URL}/read.php`);
    }
    //Добавление контакта в базу данныхх
    createUser(user) {
       
        axios.post(`${USER_API_URL}/create.php`, user);
    }
   
    //Удаление контакта из базы данных
    deleteUser(id) {
        axios.post(`${USER_API_URL}/delete.php`, id);
       
    }
    //Редактирование контакта в базе данных
    updateUser(user) {

        axios.post(`${USER_API_URL}/update.php`, user);
    }

 

}

export default new UserDataService()