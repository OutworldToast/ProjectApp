import React, { useEffect, useState } from "react";

function FetchData(){
  const [beperking, setBeperking] = useState([])

  useEffect(()=>{
    fetch('/api/Beperking')
    .then(response => response.json())
    .then(data => setBeperking(data))
    .catch(err => console.log(err))
  },[])

  return(
    <div>
      <ul>
        {beperking.map((list,index)=> (
          <li key ={index}>{list.categorie}</li>
        ))}
      </ul>
    </div>
  )
}
export default FetchData