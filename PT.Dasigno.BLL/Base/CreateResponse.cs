namespace PT.Dasigno.BLL.Base
{
    public class CreateResponse
    {
        protected CreateResponse() { }

        public static ResponseDetails ResponseNotOk()
        {
            //Cargo el objeto en caso de ser una excepcion
            ResponseDetails response = new()
            {
                Success = false
            };

            return response;
        }

        public static ResponseDetails ResponseOk(Object? Data)
        {
            ResponseDetails response = new()
            {
                Success = true,
                Data = Data
            };

            return response;
        }
    }
}
