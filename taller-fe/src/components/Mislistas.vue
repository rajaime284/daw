<template>
   <div>
      <div>
  <b-navbar toggleable="lg" type="dark" variant="info">
    <b-navbar-brand href="#">NavBar</b-navbar-brand>

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <b-nav-item href="#">Link</b-nav-item>
        <b-nav-item href="#" disabled>Disabled</b-nav-item>
      </b-navbar-nav>

      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        <b-nav-form>
          <b-form-input size="sm" class="mr-sm-2" placeholder="Search"></b-form-input>
          <b-button size="sm" class="my-2 my-sm-0" type="submit">Search</b-button>
        </b-nav-form>

        <b-nav-item-dropdown text="Lang" right>
          <b-dropdown-item href="#">EN</b-dropdown-item>
          <b-dropdown-item href="#">ES</b-dropdown-item>
          <b-dropdown-item href="#">RU</b-dropdown-item>
          <b-dropdown-item href="#">FA</b-dropdown-item>
        </b-nav-item-dropdown>

        <b-nav-item-dropdown right>
          <!-- Using 'button-content' slot -->
          <template #button-content>
            <em>User</em>
          </template>
          <b-dropdown-item href="#">Profile</b-dropdown-item>
          <b-dropdown-item href="#">Sign Out</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</div>
      <!--
      <h1>{{ titulo }}</h1>
      <button v-if="mode!='add'" v-on:click="addMode()" class="btn btn-primary">
         {{$t('add.btnNewItem')}}
      </button>

      <div class="alert alert-danger" v-if="errGet!=''">Error: {{errGet}}</div>
      
      <div class="container" v-if="errGet=='' && mode=='list'">
         <fieldset>
            <legend>{{$t('productos.titulo')}}</legend>
            <template v-for="(list) in getAll()">
               <div class="card" v-bind:key="list.id" v-if="true"
               v-bind:style="{ 'background-color': list.color}">
                  <div class="card-body">
                     test
                  </div>
               </div>
            </template>
            <div v-if="getCount()==0" class="alert alert-warning">
               {{$t('productos.noItems')}}
            </div>
         </fieldset>
      </div>

      <div class="container" v-if="errGet=='' && mode=='add'">
         <fieldset>
            <legend>{{$t('add.titulo')}}</legend>
            <form>
               <div class="form-group">
                  <label for="addListNombre">{{$t('add.lblNombre')}}</label>
                  <input ref="newList_nombre" v-model="newProducto.nombre" type="text" 
                  class="form-control" id="addListNombre" 
                  v-bind:placeholder="$t('add.ttpNombre')">
                  <span v-if="errList.nombre" class="small text-danger">
                        {{$t('add.errNombre')}}
                  </span>
               </div>
            </form>
            <div class="btn-group">
               <button v-on:click="addProducto()" class="btn btn-primary">
                  {{$t('add.btnCreate')}}
               </button>
               <button v-on:click="listMode()" class="btn btn-danger">
                  {{$t('app.btnAtras')}}
               </button>
            </div> 
            <div class="alert alert-danger" v-if="errAdd!=''">Error: {{errAdd}}</div>
         </fieldset>
      </div>-->
   </div>
</template>

<style scoped>
.tituloLista { font-size: 2em;}
</style>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import moment from 'moment';

import Producto from '@/models/Producto';

@Component({
   filters: {
      formatDate: function (value: any) {
         //TODO, verificar que hay algo en value!
         let aux = moment(value);
         return aux.format("DD/MM/YYYY hh:mm:ss");
      }
   }
})

export default class Mislistas extends Vue {
   $refs!: {
    newProducto_nombre: HTMLFormElement
  }
   @Prop() private titulo!: string;
   mode="list";
   //VUEX: lists:TaskList[]=[];
   newProducto:Producto=new Producto();
   errList= {nombre: false};
   slctVisible='T';
   errGet="";
   errAdd="";
   mounted() {
      this.$store.dispatch("getProductos");//Aqui se llama al metodo del api
      this.errGet="";
      if (this.hayError()) {
         this.errGet = this.getError();
      }
   }
   hayError() {
      return this.$store.getters.getError!=""; 
   }
   getError() {
      return this.$store.getters.getError;
   }
   getAll() {
      return this.$store.getters.getAll;
   }
   getCount() {
      return this.$store.getters.getCount;
   }
   addMode():void {
      //VUEX: let nextId= this.lists.length>0?this.lists[this.lists.length-1].id+1:+1;
      //API: let nextId= this.$store.getters.getNextId;
      this.newProducto = new Producto();
      //API: this.newList.id= nextId;
      this.mode="add";
      this.errList.nombre=false;
   }
   listMode():void {
      this.mode="list";
   }
   addProducto():void {
      if (this.newProducto.nombre != "") {
			//VUEX: this.lists.push(this.newList);
         //API: this.$store.commit('add', this.newList);
         this.$store.dispatch("addProducto", this.newProducto);
         this.errAdd="";
         if (this.hayError()) {
            this.errAdd = this.getError();
         } else {
            this.mode = 'list';
         }
		} else {
			this.errList.nombre = true;
			this.$refs.newProducto_nombre.focus();
		}
   }
   deleteList(list:number) {
      //VUEX: this.lists.splice(list, 1);
      this.$store.commit('del', list);
   }
}
</script>


