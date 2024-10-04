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
        <h1> Удаление контакта</h1>
  
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
                <h2>Вы точно хотите удалить контакт</h2>
				<p></p>
			  <p>ФИО - {{fio}}</p>
        
        <p>Номер телефона - {{tel}}</p>
       
        <p>Кем приходится - {{kto}}</p>
       
        
			</slot>
		  </section>
		  <footer class="modal-footer">
			<slot name="footer">
       
  
			  <button
				class="btnYes"
				@click="deleteUser"
				aria-label="Close modal"
			  >
				ДА
			  </button>
              <button
				class="btnNo"
				@click="close"
				aria-label="Close modal"
			  >
				НЕТ
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
      name: 'modalD',
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
		deleteUser() {
		this.userSend = []
		this.userSend.push({
        id: this.id 
      })

       UserDataService.deleteUser(this.userSend)
	   this.close()
    },
       
      close() {
      this.userName=''
      this.userTel =""
      this.userKto =""
	  this.$emit('close');
      },
      }
	
    };
    </script>



  <style scoped>
	
  </style>