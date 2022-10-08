namespace api.Repositories.ValidatorsRepository.SnilsValidator
{
    public class SnilsValidator
    {
        const int SNILS_LENGTH = 11;
        public bool Validate(string snils)
        {
            int sum = 0;
            int final_num = 0;

            if (!long.TryParse(snils, out _) || snils.Length != SNILS_LENGTH)
            {
                return false;
            }

            for (int i = 0; i < snils.Length - 2; i++)
            {
                int digit = int.Parse(snils[i].ToString());
                int coefficient = snils.Length - 2 - i;

                sum += digit * coefficient;
            }

            if (sum < 100)
            {
                final_num = sum;
            }
            else
            if (sum == 100)
            {
                final_num = 0;
            }
            else
            {
                int ost = sum % 101;

                if (ost == 100)
                {
                    final_num = 0;
                }
                else
                {
                    final_num = ost;
                }
            }

            bool checkDigit = final_num.ToString() == snils[snils.Length - 2].ToString() + snils[snils.Length - 1].ToString();

            return checkDigit;
        }
    }
}
