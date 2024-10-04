
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
        
			<h1> Добавление контакта  </h1>
		
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
			  <p>Ф.И.О.</p>
        <input type="'text" v-model="userName" placeholder="ФИО" >
        <p>Номер телефона (в формате 8(***)...)</p>
        <input type="'text" v-model="userTel" placeholder="Телефон"@input="acceptNumber">
        <p>Кем приходится</p>
        <input type="'text" v-model="userKto" placeholder="Кем приходится">
        
			</slot>
		  </section>
		  <footer class="modal-footer">
			<slot name="footer">
       
  
			  <button
				class="btn-green"
				@click="addUser"
				aria-label="Close modal"
			  >
				+ Добавить 
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
      name: 'modal',
      data() {
    return {	
      userSend:[],
      userName:this.tel,
      userTel:'',
      userKto:''
    }},
      methods: {

		acceptNumber() {
        var x = this.userTel.replace(/\D/g, '').match(/(\d{0,1})(\d{0,3})(\d{0,3})(\d{0,2})(\d{0,2})/);
  this.userTel = x[1] + (!x[3] ? x[2] : ' (' + x[2] + ') ') + x[3] + (x[4] ? '-' + x[4] : '')+ (x[5] ? '-' + x[5] : '');
    },

        addUser() {
		  this.userSend = []
      this.userSend.push({
        fio: this.userName,
        tel: this.userTel,
        kto: this.userKto
      })
      UserDataService.createUser(this.userSend)
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
      }
	
    };
    </script>



  <style scoped>


  </style>