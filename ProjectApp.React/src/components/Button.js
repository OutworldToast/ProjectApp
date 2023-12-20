function Button({message, body}) {

    function onClick() {
        alert(message);
    }

    return (
        <button onClick = {onClick}>
            {body}
        </button>
    )
}

export default Button;