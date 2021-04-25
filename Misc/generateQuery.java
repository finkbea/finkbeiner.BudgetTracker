import java.util.Random;
import java.io.PrintWriter;
import java.io.IOException;
public class generateQuery{
    public static void main(String[] args) throws IOException{
        String[] incomes= new String[300];
        String[] expenditures = new String[300];
        Random r = new Random();
        PrintWriter Ewriter = new PrintWriter("expenditures.sql", "UTF-8");
        PrintWriter Iwriter = new PrintWriter("incomes.sql", "UTF-8");

        for (int i = 0; i < 300; i++){
            int i2 = i+1;
            String a ="INSERT [dbo].[Incomes] ([Id], [UserId], [Amount], [Description], [IncomeDate], [Remarks]) Values (";
            a+= i2+", "+(r.nextInt(25)+1) + ", '" + (r.nextInt(100000)+1) + "', 'Money was earned', '";
            int year = r.nextInt(8)+2012;
            int month = r.nextInt(12)+1;
            int day = r.nextInt(28)+1;
            String date = year+"-"+month+"-"+day;
            a+= date+"', 'This is a remark for the income')";
            incomes[i]=a;
        }

        for (int i = 0; i < 300; i++){
            int i2 = i+1;
            String a ="INSERT [dbo].[Expenditures] ([Id], [UserId], [Amount], [Description], [ExpDate], [Remarks]) Values (";
            a+= i2+", "+(r.nextInt(25)+1) + ", '" + (r.nextInt(100000)+1) + "', 'Money was spent', '";
            int year = r.nextInt(8)+2012;
            int month = r.nextInt(12)+1;
            int day = r.nextInt(28)+1;
            String date = year+"-"+month+"-"+day;
            a+= date+"', 'This is a remark for the expenditure')";
            expenditures[i]=a;
        }
        for (int i = 0; i < incomes.length; i++){
            Iwriter.println(incomes[i]);
            Ewriter.println(expenditures[i]);
            Iwriter.flush();
            Ewriter.flush();
        }

    }
}
