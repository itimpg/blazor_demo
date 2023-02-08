using Ardalis.SmartEnum;

namespace SellerPortal.Core.Enums
{
    public class ModalTypes : SmartEnum<ModalTypes>
    {
        public static readonly ModalTypes Success = new ModalTypes("Success", 1);
        public static readonly ModalTypes Warning = new ModalTypes("Warning", 2);
        public static readonly ModalTypes Error = new ModalTypes("Error", 3);
        public static readonly ModalTypes Confirm = new ModalTypes("Confirm", 4);

        private ModalTypes(string name, int value) : base(name, value)
        {
        }
    }
}
