<template>

 <modal
 v-show="isModalVisible"
 @close="closeModal"
/>
<modalR
 v-show="isModalRVisible"
 :id = 'userid'
 :fio ='userName'
 :tel ='userTel'
 :kto='userKto'
 @close="closeModal"
/>
<modalD
 v-show="isModalDVisible"
 :id = 'userid'
 :fio ='userName'
 :tel ='userTel'
 :kto='userKto'
 @close="closeModal"
/>



 <table class="table">
  <thead>
  <tr><th>ФИО</th><th>Телефон</th><th>Кем приходится</th> <th><button @click="addUser" class="btn3">+ Добавить </button></th></tr>
 <tr v-for="user in users" :key="user.id"v-bind:Wuser="user" >

  <td>{{ user.fio }}</td>
  <td>{{ user.tel }}</td>
  <td>{{ user.kto }}</td>
  <td>
	<button v-on:click="updateUser(user.id,user.fio,user.tel,user.kto)" class="btn">
      Редактировать
    </button>
    <button  v-on:click="deleteUser(user.id,user.fio,user.tel,user.kto)"class="btn2">
      Удалить
    </button>
 
  </td>
</tr>
</thead>
</table>

</template>

<script>
import UserDataService from "./components/UserDataService";
import modal from './components/input_win.vue';
import modalR from './components/red_win.vue';
import modalD from './components/del_win.vue';





   

export default{
	name: 'app',
    components: {
      modal,modalR,modalD
    },
  data() {
    return {	
	isModalVisible: false,
	isModalRVisible: false,
	isModalDVisible: false,
      users: [],
	  userid:'',
      userName:'',
      userTel:'',
      userKto:''
    }
 
  }, 
  methods:{
	//Вызов диалогового окна для добавления пользователя
	addUser() {
        this.isModalVisible = true;
		
      },
	  // Закрытие диалогового окна
      closeModal() {
        this.isModalVisible = false;
		this.isModalRVisible = false;
		this.isModalDVisible = false;
		setTimeout(()=>{
		this.refreshUsers()},70);
      },
    //Обновление таблицы 
    refreshUsers() {
      UserDataService.retrieveAllUsers().then((res) => {
        this.users = res.data;
      });
    },
	// Вызов диалогового окна удаления пользователя
	deleteUser(id,fio,tel,kto) {
		this.userid = id
		this.userName =fio
		this.userTel = tel
		this.userKto = kto
		this.isModalDVisible = true;
    },
	// Вызов диалогового окна для редактирования
    updateUser(id,fio,tel,kto) {
		
		this.userid = id
		this.userName =fio
		this.userTel = tel
		this.userKto = kto
		this.isModalRVisible = true;
    }
    },
    
    created() {
    this.refreshUsers();
  },
  }

</script>
<style scoped>


</style>
