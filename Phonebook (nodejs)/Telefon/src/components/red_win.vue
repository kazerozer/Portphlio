<template>
	<transition name="modal-fade">
	  <div class="modal-backdrop">
		<div class="modal"
		  role="dialog"
		  aria-labelledby="modalTitle"
		  aria-describedby="modalDescription"
		>
		  <header
			class="modal-header"
			id="modalTitle"
		  >
			<slot name="header">
        <h1> Редактирование контакта</h1>
  
			  <button
				type="button"
				class="btn-close"
				@click="close"
				aria-label="Close modal"
			  >
				Х
			  </button>
			</slot>
		  </header>
		  <section
			class="modal-body"
			id="modalDescription"
		  >
			<slot name="body">
			  <p>ФИО</p>
        <input type="'text" v-model="userName" placeholder="ФИО" @click ="test">
        <p>Номер телефона</p>
        <input type="'text" v-model="userTel" placeholder="Телефон" @click ="test">
        <p>Кем приходится</p>
        <input type="'text" v-model="userKto" placeholder="Кем приходится" @click ="test">
        
			</slot>
		  </section>
		  <footer class="modal-footer">
			<slot name="footer">
       
  
			  <button
				class="btn-green"
				@click="updateUser"
				aria-label="Close modal"
			  >
				Отредактировать
			  </button>
			</slot>
		  </footer>
		</div>
	  </div>
	</transition>
  </template>

  <script>
  import UserDataService from "./UserDataService";

    export default {
      name: 'modalR',
	  props:{
		id:String,
		fio:String,
		tel:String,
		kto:String

	  },
      data() {
    return {	
      userSend:[],
      userName:'',
      userTel:'',
      userKto:''
    }},
    methods: {
		test(fio){
			this.userName = this.fio,
			this.userTel =this.tel,
			this.userKto = this.kto
		},
       
    
    updateUser() {
		this.userSend = []
		this.userSend.push({
		id:	this.id,
        fio: this.userName,
        tel: this.userTel,
        kto: this.userKto
      })
      UserDataService.updateUser(this.userSend)
	  this.userName=""
      this.userTel =""
      this.userKto =""
      this.close()
    },
      close() {
      this.userName=''
      this.userTel =""
      this.userKto =""
	  this.$emit('close');
      },
      },
	  created() {
		this.userName = this.fio,
			this.userTel =this.tel,
			this.userKto = this.kto
  }
    };
    </script>



  <style scoped>

	

  </style>