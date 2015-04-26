using TecxoftRequest;
using System.IO;
using System;

public class TestSignRequest {

	public static void Main(){
		System.Console.WriteLine("Sending sign request..");
		// read file
		byte[] bytes = File.ReadAllBytes("C:\\files\\pdf_input.pdf");
		SignRequest req = new SignRequest("442266", "password");
		try{
			Stream stream = req.sendSignRequest(bytes);
			FileStream fileStream = new FileStream("C:\\files\\output\\pdf_output.pdf", FileMode.Create, FileAccess.Write);
			CopyStream(stream, fileStream);
			fileStream.Close();	
			System.Console.WriteLine("File written.");					
		}catch(Exception exp){
			System.Console.WriteLine(exp.ToString());
		}
	}
  
	public static void CopyStream(Stream input, Stream output){
		byte[] buffer = new byte[32768];
		int read;
		while ((read = input.Read(buffer, 0, buffer.Length)) > 0){
			output.Write (buffer, 0, read);
		}
	}

}  