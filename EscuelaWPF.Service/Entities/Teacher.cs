
namespace EscuelaWPF.Service
{
    public class Teacher : Entity
    {
        /*"id": 888888888,
        "name": "B",
        "last_name": "C",
        "phone_num": "88888888",
        "state_id": 1 */

        #region Public Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Last_name {get; set;}
        public string Phone_num { get; set; }
        public int State_id { get; set; }

        public string Image { get; set; }

        #endregion
        public Teacher()
        {

        }
        public override string ToString()
        {
            return Name + " " + Last_name;
        }
    }
}
