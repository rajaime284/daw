import Vue from 'vue'
import Vuex from 'vuex'

import serviceAPI from '@/services/service'; // @ is an alias to /src
import { APIStatus } from '@/http-config';
import Producto from '@/models/Producto';

Vue.use(Vuex)

export default new Vuex.Store({
   state: {
      productos: Array<Producto>(),
      error: ""
   },
   getters: {
      getAll(state) {
         return state.productos;
      },
      getCount(state) {
         return state.productos.length;
      },
      getNextId(state) {
         return state.productos.length>0?state.productos[state.productos.length-1].id+1:1;
      },
      getError(state) {
         return state.error;
      }
   },
   mutations: {
      setProductos(state, productos) {
         state.productos = productos;
      },
      add(state, producto: Producto) {
         state.productos.push(producto);
      },
      del(state, index: number) {
         state.productos.splice(index, 1);
      },
   },
   actions: {
      getProductos({ commit }) {
         this.state.error="";
         serviceAPI.getRaw("Producto/ReadAll").then(r=> {
            if (r.status==APIStatus.OK) {
               commit('setProductos', r.respuesta)
            } else {
               this.state.error=r.error;   
            }
         }).catch(e=> {
            this.state.error=e;
         });
      }, 
      addProducto({ commit }, producto) {
         this.state.error="";
         serviceAPI.post("Producto/Nuevo", producto).then(r=> {
            if (r.status==APIStatus.OK) {
               commit('add', r.respuesta)
            } else {
               this.state.error=r.error;   
            }
         }).catch(e=> {
            this.state.error=e;
         });
      }
   },
   modules: {
   }
})
